using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using ARM.Data.Interfaces.Student;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Student
{
    public class StudentContext : BaseContext<Models.Student>,IStudentContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //student
            modelBuilder.Entity<Models.Student>()
                .HasRequired(s => s.Address)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Models.Student>()
                .HasRequired(s => s.LivingAddress)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Models.Person>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Models.Student>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Student");
            });
        }
    }
}