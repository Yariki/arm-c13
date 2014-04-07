using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ARM.Data.Interfaces.Achivement;
using ARM.Data.Interfaces.Address;
using ARM.Data.Interfaces.Class;
using ARM.Data.Interfaces.Contract;
using ARM.Data.Interfaces.Country;
using ARM.Data.Interfaces.Faculty;
using ARM.Data.Interfaces.Group;
using ARM.Data.Interfaces.Hobby;
using ARM.Data.Interfaces.Invoice;
using ARM.Data.Interfaces.Language;
using ARM.Data.Interfaces.Mark;
using ARM.Data.Interfaces.Parent;
using ARM.Data.Interfaces.Payment;
using ARM.Data.Interfaces.Session;
using ARM.Data.Interfaces.Settings;
using ARM.Data.Interfaces.Specialty;
using ARM.Data.Interfaces.Staff;
using ARM.Data.Interfaces.Student;
using ARM.Data.Interfaces.University;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;
using ARM.Data.Models;

namespace ARM.Data.Layer
{
    // this class is used only for migrations at all.
    public class CommonContext : DbContext
    {

        public CommonContext()
            : base("ARMDatabase")
        {
            Database.CreateIfNotExists();
        }

        #region [dbsets]
        
        public DbSet<Achivement> Achivements { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SettingParameters> SettingParameterses { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Staff> Staves { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }

        #endregion

        #region [model builder]

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
            base.OnModelCreating(modelBuilder);
            //contract
            modelBuilder.Entity<Contract>()
                .HasRequired(c => c.Student)
                .WithMany(c =>c.Contracts)
                .HasForeignKey(c => c.StudentId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Contract>()
                .HasRequired(c =>c.Customer)
                .WithMany(c =>c.Contracts)
                .HasForeignKey(c =>c.ParentId)
                .WillCascadeOnDelete(false);
            // marks
            modelBuilder.Entity<Mark>()
                .HasRequired(c => c.Student)
                .WithMany(c =>c.Marks)
                .HasForeignKey(c => c.StudentId)
                .WillCascadeOnDelete(false);
            //student
            modelBuilder.Entity<Student>()
                .HasRequired(s => s.Address)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Student>()
                .HasRequired(s => s.LivingAddress)
                .WithMany()
                .WillCascadeOnDelete(false);
            //table per concrete class
            modelBuilder.Entity<Person>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Parent>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Parent");
            });
            modelBuilder.Entity<Staff>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Staff");
            });
            modelBuilder.Entity<Student>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Student");
            });

        }

        #endregion


    }
}