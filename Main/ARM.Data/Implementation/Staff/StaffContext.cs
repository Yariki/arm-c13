using System.Data.Entity;
using ARM.Data.Interfaces.Staff;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Staff
{
    /// <summary>
    /// Контекст бази даних для працівників
    /// </summary>
    public class StaffContext : BaseContext<Models.Staff>, IStaffContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Staff>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Staff");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}