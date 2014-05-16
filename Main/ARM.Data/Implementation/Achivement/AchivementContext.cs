using System.Data.Entity;
using ARM.Data.Interfaces.Achivement;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Achivement
{
    public class AchivementContext : BaseContext<Models.Achivement>, IAchivementContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Achivement>()
                 .HasRequired<Models.Student>(h => h.Student)
                 .WithMany(s => s.Achivements)
                 .HasForeignKey(h => h.StudentId)
                 .WillCascadeOnDelete();
            base.OnModelCreating(modelBuilder);
        }
    }
}