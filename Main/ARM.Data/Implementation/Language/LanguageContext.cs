using System.Data.Entity;
using ARM.Data.Interfaces.Language;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Language
{
    /// <summary>
    /// Контекст бази даних для мов
    /// </summary>
    public class LanguageContext : BaseContext<Models.Language>, ILanguageContext
    {
        /// <summary>
        /// Створити екземпляр <see cref="LanguageContext"/> class.
        /// </summary>
        public LanguageContext()
        {
            
        }
        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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