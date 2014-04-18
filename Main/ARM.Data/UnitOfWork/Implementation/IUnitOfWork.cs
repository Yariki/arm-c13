using System;
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
using ARM.Data.Interfaces.User;

namespace ARM.Data.UnitOfWork.Implementation
{
    public interface IUnitOfWork : IDisposable
    {
        IAchivementBll AchivementRepository { get; }
        IAddressBll AddressRepository { get; }
        IClassBll ClassRepository { get; }
        IContractBll ContractRepository { get; }
        ICountryBll CountryRepository { get; }
        IFacultyBll FacultyRepository { get; }
        IGroupBll GroupRepository { get; }
        IHobbyBll HobbyRepository { get; }
        IInvoiceBll InvoiseRepository { get; }
        ILanguageBll LanguageRepository { get; }
        IMarkBll MarkRepository { get; }
        IParentBll ParentReposotory { get; }
        IPaymentBll PaymentRepository { get; }
        ISessionBll SessionRepository { get; }
        ISettingsBll SettingsRepository { get; }
        ISpecialtyBll SpeciltyRepository { get; }
        IStaffBll StaffRepository { get; }
        IStudentBll StudentRepository { get; }
        IUniversityBll UniversityRepository { get; }
        IUserBll UserRepository { get; }
    }
}