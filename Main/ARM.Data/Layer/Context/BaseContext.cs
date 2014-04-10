using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ARM.Data.Layer.Interfaces;
using ARM.Data.Models;
using NSubstitute;

namespace ARM.Data.Layer.Context
{
    public abstract class BaseContext<T> : DbContext, IContext<T> where T : BaseModel
    {

        protected BaseContext()
            : base("ARMDatabase")
        { }

        public DbSet<T> Items { get; set; }

        public IDbSet<T> GetItems()
        {
            return Items;
        }

        public void Save()
        {
            foreach (var entry in ChangeTracker.Entries<T>().Where(e => e.State == EntityState.Added))
            {
                entry.Entity.Id = Guid.NewGuid();
            }
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}