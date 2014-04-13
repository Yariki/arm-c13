using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
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

        public void Update(T obj)
        {
            if(obj == null)
                return;
            var entry = base.Entry<T>(obj);
            if (entry.State == EntityState.Detached)
            {
                T attached = Items.Find(obj.Id);
                if (attached != null)
                {
                    var attachedEntry = base.Entry(attached);
                    attachedEntry.CurrentValues.SetValues(obj);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

        public void Refresh()
        {
            IObjectContextAdapter oca = this as IObjectContextAdapter;
            if(oca == null)
                return;
            ObjectContext context = oca.ObjectContext;
            var refreshableObjects = (from entry in context.ObjectStateManager.GetObjectStateEntries(
                                                EntityState.Added 
                                               | EntityState.Deleted 
                                               | EntityState.Modified 
                                               | EntityState.Unchanged)
                                      where entry.EntityKey != null
                                      select entry.Entity);
            context.Refresh(RefreshMode.StoreWins, refreshableObjects );
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}