using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
            base.OnModelCreating(modelBuilder);
        }
    }
}