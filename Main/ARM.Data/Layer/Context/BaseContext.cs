using System.Data.Entity;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Layer.Context
{
    public abstract class BaseContext<T> : DbContext, IContext<T> where T : class
    {

        public BaseContext()
            : base("ARMDatabase")
        {}

        public DbSet<T> Items { get; set; }

        public IDbSet<T> GetItems()
        {
            return Items;
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}