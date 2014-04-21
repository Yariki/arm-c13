using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using ARM.Data.Interfaces.Parent;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Parent
{
    public class ParentContext : BaseContext<Models.Parent>,IParentContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Parent>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Parent");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}