using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ARM.Data.Layer.Interfaces;
using ARM.Data.Models;

namespace ARM.Data.Layer.Context
{
    public abstract class BaseContext<T> : DbContext, IContext<T> where T : BaseModel
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
            modelBuilder.Entity<T>().Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //base.OnModelCreating(modelBuilder);
        }
    }
}