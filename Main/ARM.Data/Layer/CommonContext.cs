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
    public class CommonContext : BaseContext, IAchivementContext, IAddressContext, IClassContext, IContractContext, ICountryContext, IFacultyContext, IGroupContext, IHobbyContext,
        IInvoiceContext, ILanguageContext, IMarkContext, IParentContext, IPaymentContext, ISessionContext, ISettingsContext, ISpecialtyContext, IStaffContext, IStudentContext, IUniversityContext
    {
        DbSet<Achivement> IContext<Achivement>.Items
        {
            get;
            set;
        }

        DbSet<Address> IContext<Address>.Items
        {
            get;
            set;
        }

        DbSet<Class> IContext<Class>.Items
        {
            get;
            set;
        }

        DbSet<Contract> IContext<Contract>.Items
        {
            get;
            set;
        }

        DbSet<Country> IContext<Country>.Items
        {
            get;
            set;
        }

        DbSet<Faculty> IContext<Faculty>.Items
        {
            get;
            set;
        }

        DbSet<Group> IContext<Group>.Items
        {
            get;
            set;
        }

        DbSet<Hobby> IContext<Hobby>.Items
        {
            get;
            set;
        }

        DbSet<Invoice> IContext<Invoice>.Items
        {
            get;
            set;
        }

        DbSet<Language> IContext<Language>.Items
        {
            get;
            set;
        }

        DbSet<Mark> IContext<Mark>.Items
        {
            get;
            set;
        }

        DbSet<Parent> IContext<Parent>.Items
        {
            get;
            set;
        }

        DbSet<Payment> IContext<Payment>.Items
        {
            get;
            set;
        }

        DbSet<Session> IContext<Session>.Items
        {
            get;
            set;
        }

        DbSet<SettingParameters> IContext<SettingParameters>.Items
        {
            get;
            set;
        }

        DbSet<Specialty> IContext<Specialty>.Items
        {
            get;
            set;
        }

        DbSet<Staff> IContext<Staff>.Items
        {
            get;
            set;
        }

        DbSet<Student> IContext<Student>.Items
        {
            get;
            set;
        }

        DbSet<University> IContext<University>.Items
        {
            get;
            set;
        }
    }
}