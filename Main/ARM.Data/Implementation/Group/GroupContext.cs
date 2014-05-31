using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using ARM.Data.Interfaces.Group;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Group
{
    /// <summary>
    /// Контекст бази даних для груп
    /// </summary>
    public class GroupContext : BaseContext<Models.Group>, IGroupContext
    {
        /// <summary>
        /// Створити екземпляр <see cref="GroupContext"/> class.
        /// </summary>
        public GroupContext()
        {
            
        }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Student>()
                .HasRequired(s => s.Address)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Models.Student>()
                .HasRequired(s => s.LivingAddress)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Models.Student>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Student");
            });
            modelBuilder.Entity<Models.Language>()
                .HasMany(a => a.Students)
                .WithMany(p => p.Languages)
                .Map(m =>
                {
                    m.MapLeftKey("LanguageId");
                    m.MapRightKey("StudentId");
                    m.ToTable("StudentLanguages");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}