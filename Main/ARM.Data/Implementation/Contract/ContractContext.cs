using System.Data.Entity;
using ARM.Data.Interfaces.Contract;
using ARM.Data.Layer.Context;

namespace ARM.Data.Implementation.Contract
{
    public class ContractContext : BaseContext<Models.Contract>,IContractContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //contract
            modelBuilder.Entity<Models.Contract>()
                .HasRequired(c => c.Student)
                .WithMany(c => c.Contracts)
                .HasForeignKey(c => c.StudentId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Models.Contract>()
                .HasRequired(c => c.Customer)
                .WithMany(c => c.Contracts)
                .HasForeignKey(c => c.ParentId)
                .WillCascadeOnDelete(false);
        }
    }
}