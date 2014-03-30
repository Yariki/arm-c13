using System.Data.Entity;
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
    public class CommonContext : DbContext, IAchivementContext, IAddressContext, IClassContext, IContractContext, ICountryContext, IFacultyContext, IGroupContext, IHobbyContext,
        IInvoiceContext, ILanguageContext, IMarkContext, IParentContext, IPaymentContext, ISessionContext, ISettingsContext, ISpecialtyContext, IStaffContext, IStudentContext, IUniversityContext
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

        }

        #endregion

        IDbSet<Achivement> IContext<Achivement>.GetItems()
        {
            return Achivements;
        }

        IDbSet<Address> IContext<Address>.GetItems()
        {
            return Addresses;
        }

        IDbSet<Class> IContext<Class>.GetItems()
        {
            return Classes;
        }

        IDbSet<Contract> IContext<Contract>.GetItems()
        {
            return Contracts;
        }

        IDbSet<Country> IContext<Country>.GetItems()
        {
            return Countries;
        }

        IDbSet<Faculty> IContext<Faculty>.GetItems()
        {
            return Faculties;
        }

        IDbSet<Group> IContext<Group>.GetItems()
        {
            return Groups;
        }

        IDbSet<Hobby> IContext<Hobby>.GetItems()
        {
            return Hobbies;
        }

        IDbSet<Invoice> IContext<Invoice>.GetItems()
        {
            return Invoices;
        }

        IDbSet<Language> IContext<Language>.GetItems()
        {
            return Languages;
        }

        IDbSet<Mark> IContext<Mark>.GetItems()
        {
            return Marks;
        }

        IDbSet<Parent> IContext<Parent>.GetItems()
        {
            return Parents;
        }

        IDbSet<Payment> IContext<Payment>.GetItems()
        {
            return Payments;
        }

        IDbSet<Session> IContext<Session>.GetItems()
        {
            return Sessions;
        }

        IDbSet<SettingParameters> IContext<SettingParameters>.GetItems()
        {
            return SettingParameterses;
        }

        IDbSet<Specialty> IContext<Specialty>.GetItems()
        {
            return Specialties;
        }

        IDbSet<Staff> IContext<Staff>.GetItems()
        {
            return Staves;
        }

        IDbSet<Student> IContext<Student>.GetItems()
        {
            return Students;
        }

        IDbSet<University> IContext<University>.GetItems()
        {
            return Universities;
        }

        public void Save()
        {
            this.SaveChanges();
        }

    }
}