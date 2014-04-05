using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Unity.AutoRegistration;

namespace ARMAutoReg
{

    interface IObject
    {
        void toString();
    }

    interface IFirstObject : IObject
    {
    }

    interface ISecondObject : IObject
    {
    }

    abstract class MyObject : IObject
    {
        public virtual void toString()
        {   
        }
    }

    class First : MyObject, IFirstObject
    {
        public override string ToString()
        {
            return "First";
        }
    }

    class Second : MyObject, ISecondObject
    {
        public override string ToString()
        {
            return "Second";
        }
    }

    interface IContext<T>
    {
        IList<T> Set { get; } 
    }

    interface IIntContext : IContext<int>
    {
         
    }

    class IntContext : IIntContext
    {
        private IList<int> _set;

        public IList<int> Set
        {
            get { return _set; }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container
                .ConfigureAutoRegistration()
                .ExcludeSystemAssemblies()
                .Include(If.Implements<IObject>,Then.Register().UsingPerCallMode())
                .Include(type => type.ImplementsOpenGeneric(typeof(IContext<>)),Then.Register().UsingPerCallMode())
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
