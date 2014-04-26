using System.Data.Entity;
using ARM.Data.Interfaces.Language;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Language
{
    public class LanguageContext : BaseContext<Models.Language>,ILanguageContext
    {
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