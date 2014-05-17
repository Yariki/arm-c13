using System.Data.Entity;
using ARM.Data.Interfaces.Hobby;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Hobby
{
    /// <summary>
    /// Контекст бази даних для хобі
    /// </summary>
    public class HobbyContext : BaseContext<Models.Hobby>, IHobbyContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Hobby>()
                .HasRequired<Models.Student>(h => h.Student)
                .WithMany(s => s.Hobbies)
                .HasForeignKey(h => h.StudentId)
                .WillCascadeOnDelete();
            base.OnModelCreating(modelBuilder);
        }
    }
}