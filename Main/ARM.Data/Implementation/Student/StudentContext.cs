using System.Data.Entity;
using System.Linq;
using ARM.Data.Interfaces.Student;
using ARM.Data.Layer.Context;
using Microsoft.Practices.ObjectBuilder2;

namespace ARM.Data.Implementation.Student
{
    /// <summary>
    /// Контекст бази даних для студентів
    /// </summary>
    public class StudentContext : BaseContext<Models.Student>, IStudentContext
    {
        public DbSet<Models.Language> Languages { get; set; }

        public DbSet<Models.Hobby> Hobbies { get; set; }

        public DbSet<Models.Achivement> Achivements { get; set; }

        public DbSet<Models.Visa> Visas { get; set; }

        public DbSet<Models.Parent> Parents { get; set; }

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

            modelBuilder.Entity<Models.Parent>()
              .HasOptional<Models.Student>(p => p.Child)
              .WithMany(s => s.Parents)
              .HasForeignKey(p => p.StudentId)
              .WillCascadeOnDelete(false);
            modelBuilder.Entity<Models.Student>()
                .HasMany<Models.Parent>(s => s.Parents)
                .WithOptional(p => p.Child)
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
            //student
        }

        protected override void UpdateChilds(Models.Student attached, Models.Student current)
        {
            if (attached.Languages != null && current.Languages != null && current.Languages.Count > 0)
            {
                attached.Languages.Clear();

                current.Languages.Select(l => l.Id).ForEach(id =>
                {
                    var language = Languages.Find(id);
                    if (language != null)
                    {
                        attached.Languages.Add(language);
                    }
                });
            }
            base.UpdateChilds(attached, current);
        }
    }
}