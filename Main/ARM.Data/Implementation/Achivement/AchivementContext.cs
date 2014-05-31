using System.Data.Entity;
using ARM.Data.Interfaces.Achivement;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Achivement
{
    /// <summary>
    /// Контекст бази даних для досягнень
    /// </summary>
    public class AchivementContext : BaseContext<Models.Achivement>, IAchivementContext
    {
        /// <summary>
        /// Створити екземпляр <see cref="AchivementContext"/> class.
        /// </summary>
        public AchivementContext()
        {
            
        }
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