using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Unity.AutoRegistration;

namespace ARMAutoReg
{
    internal interface IObject
    {
        void toString();
    }

    internal interface IFirstObject : IObject
    {
    }

    internal interface ISecondObject : IObject
    {
    }

    internal abstract class MyObject : IObject
    {
        public virtual void toString()
        {
        }
    }

    internal class First : MyObject, IFirstObject
    {
        public override string ToString()
        {
            return "First";
        }
    }

    internal class Second : MyObject, ISecondObject
    {
        public override string ToString()
        {
            return "Second";
        }
    }

    internal interface IContext<T>
    {
        IList<T> Set { get; }
    }

    internal interface IIntContext : IContext<int>
    {
    }

    internal class IntContext : IIntContext
    {
        private IList<int> _set;

        public IList<int> Set
        {
            get { return _set; }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container
                .ConfigureAutoRegistration()
                .ExcludeSystemAssemblies()
                .Include(If.Implements<IObject>, Then.Register().UsingPerCallMode())
                .Include(type => type.ImplementsOpenGeneric(typeof(IContext<>)), Then.Register().UsingPerCallMode())
                .ApplyAutoRegistration();

            var f = container.Resolve<IFirstObject>();
            Console.WriteLine(f);
            var s = container.Resolve<ISecondObject>();
            Console.WriteLine(s);
            var con = container.Resolve<IIntContext>();
            Console.WriteLine(con);
            Console.ReadLine();
        }
    }
}