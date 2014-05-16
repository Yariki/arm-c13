using System.Data.Entity;
using ARM.Data.Interfaces.Mark;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Mark
{
    public class MarkContext : BaseContext<Models.Mark>, IMarkContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // marks
            modelBuilder.Entity<Models.Mark>()
                .HasRequired(c => c.Student)
                .WithMany(c => c.Marks)
                .HasForeignKey(c => c.StudentId)
                .WillCascadeOnDelete(false);
        }
    }
}