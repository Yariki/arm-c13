using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ARM.Data.Layer.Interfaces;
using ARM.Data.Models;

namespace ARM.Data.Layer.Context
{
    /// <summary>
    /// Абстрактна реалізація конексту БД.
    /// </summary>
    /// <typeparam name="T">Тип моделі даних</typeparam>
    public abstract class BaseContext<T> : DbContext, IContext<T> where T : BaseModel
    {
        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="BaseContext{T}"/>.
        /// </summary>
        protected BaseContext()
            : base("ARMDatabase")
        {
        }

        /// <summary>
        /// Отримує або задає записи.
        /// </summary>
        public DbSet<T> Items { get; set; }

        /// <summary>
        /// Отримує всі записи.
        /// </summary>
        /// <returns></returns>
        public IDbSet<T> GetItems()
        {
            return Items;
        }

        /// <summary>
        /// Зберігає зміни до БД.
        /// </summary>
        public void Save()
        {
            foreach (var entry in ChangeTracker.Entries<T>().Where(e => e.State == EntityState.Added))
            {
                if (entry.Entity.Id == Guid.Empty)
                {
                    entry.Entity.Id = Guid.NewGuid();
                }
            }
            SaveChanges();
        }

        /// <summary>
        /// Оновлює елемент в БД.
        /// </summary>
        /// <param name="obj">Елемент.</param>
        public void Update(T obj)
        {
            if (obj == null)
                return;
            var entry = base.Entry<T>(obj);
            if (entry.State == EntityState.Detached)
            {
                T attached = Items.Find(obj.Id);
                if (attached != null)
                {
                    var attachedEntry = base.Entry(attached);
                    attachedEntry.CurrentValues.SetValues(obj);
                    UpdateChilds(attached, obj);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
        }

        /// <summary>
        /// Обновляє дані з БД.
        /// </summary>
        public void Refresh()
        {
            IObjectContextAdapter oca = this as IObjectContextAdapter;
            if (oca == null)
                return;
            ObjectContext context = oca.ObjectContext;
            var refreshableObjects = (from entry in context.ObjectStateManager.GetObjectStateEntries(
                                                EntityState.Added
                                               | EntityState.Deleted
                                               | EntityState.Modified
                                               | EntityState.Unchanged)
                                      where entry.EntityKey != null
                                      select entry.Entity);
            context.Refresh(RefreshMode.StoreWins, refreshableObjects);
        }

        /// <summary>
        ///Повертає спеціальни внутрішній обєкт EF.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        public DbEntityEntry<T> Entry(T e)
        {
            return base.Entry(e);
        }

        /// <summary>
        /// Повертає набір записів типу.
        /// </summary>
        /// <typeparam name="TObj">Тип моделі даних.</typeparam>
        /// <returns></returns>
        public new DbSet<TObj> Set<TObj>() where TObj : BaseModel
        {
            return Set<TObj>();
        }

        /// <summary>
        /// Оновлення залежних записів.
        /// </summary>
        /// <param name="attached">Внутрішній обєкт.</param>
        /// <param name="current">Обєкті, дані якого переносяться.</param>
        protected virtual void UpdateChilds(T attached, T current)
        {
        }

        /// <summary>
        /// Викликається при [модель Створення].
        /// </summary>
        /// <param name="modelBuilder">Модель будівельник.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}