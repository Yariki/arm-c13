using System.Data.Entity;
using ARM.Data.Interfaces.Visa;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Visa
{
    /// <summary>
    /// Контекст бази даних для віз
    /// </summary>
    public class VisaContext : BaseContext<Models.Visa>, IVisaContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //visas
            modelBuilder.Entity<Models.Visa>()
                .HasRequired<Models.Student>(h => h.Student)
                .WithMany(s => s.Visas)
                .HasForeignKey(h => h.StudentId)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}