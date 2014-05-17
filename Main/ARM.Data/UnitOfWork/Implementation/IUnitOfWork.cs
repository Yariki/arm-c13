using System;
using ARM.Data.Interfaces.Achivement;
using ARM.Data.Interfaces.Address;
using ARM.Data.Interfaces.Class;
using ARM.Data.Interfaces.Contract;
using ARM.Data.Interfaces.Country;
using ARM.Data.Interfaces.Employer;
using ARM.Data.Interfaces.Faculty;
using ARM.Data.Interfaces.Group;
using ARM.Data.Interfaces.Hobby;
using ARM.Data.Interfaces.Invoice;
using ARM.Data.Interfaces.Language;
using ARM.Data.Interfaces.Mark;
using ARM.Data.Interfaces.Parent;
using ARM.Data.Interfaces.Payment;
using ARM.Data.Interfaces.Rate;
using ARM.Data.Interfaces.Session;
using ARM.Data.Interfaces.Settings;
using ARM.Data.Interfaces.Specialty;
using ARM.Data.Interfaces.Staff;
using ARM.Data.Interfaces.Student;
using ARM.Data.Interfaces.University;
using ARM.Data.Interfaces.User;
using ARM.Data.Interfaces.Visa;

namespace ARM.Data.UnitOfWork.Implementation
{
    /// <summary>
    /// Інтерфейс, що відповідає за централізований доступ до всіх репозитарії, та їх видалення 
    /// у разі закінчення роботи з ними.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Отримує сховище Досягнення.
        /// </summary>
        IAchivementBll AchivementRepository { get; }

        /// <summary>
        /// Отримує сховище адресу.
        /// </summary>
        IAddressBll AddressRepository { get; }

        /// <summary>
        /// Отримує сховище класу.
        /// </summary>
        IClassBll ClassRepository { get; }

        /// <summary>
        /// Отримує сховище контракту.
        /// </summary>
        IContractBll ContractRepository { get; }

        /// <summary>
        /// Отримує сховищ країни.
        /// </summary>
        ICountryBll CountryRepository { get; }

        /// <summary>
        /// Отримує сховище факультету.
        /// </summary>
        IFacultyBll FacultyRepository { get; }

        /// <summary>
        /// Отримує сховище групи.
        /// </summary>
        IGroupBll GroupRepository { get; }

        /// <summary>
        /// Отримує сховище хобі.
        /// </summary>
        IHobbyBll HobbyRepository { get; }

        /// <summary>
        /// Отримує сховище invoise.
        /// </summary>
        IInvoiceBll InvoiseRepository { get; }

        /// <summary>
        /// Отримує сховище мови.
        /// </summary>
        ILanguageBll LanguageRepository { get; }

        /// <summary>
        /// Отримує сховище оцінок.
        /// </summary>
        IMarkBll MarkRepository { get; }

        /// <summary>
        /// Повертає батьківський репозиторій.
        /// </summary>
        IParentBll ParentRepository { get; }

        /// <summary>
        /// Отримує сховище оплати.
        /// </summary>
        IPaymentBll PaymentRepository { get; }

        /// <summary>
        /// Отримує сховище сесії.
        /// </summary>
        ISessionBll SessionRepository { get; }

        /// <summary>
        /// Отримує сховище налаштувань.
        /// </summary>
        ISettingsBll SettingsRepository { get; }

        /// <summary>
        ///Отримує сховище спеціальності.
        /// </summary>
        ISpecialtyBll SpeciltyRepository { get; }

        /// <summary>
        /// Отримує сховище персоналу.
        /// </summary>
        IStaffBll StaffRepository { get; }

        /// <summary>
        /// Отримує сховище студентів.
        /// </summary>
        IStudentBll StudentRepository { get; }

        /// <summary>
        /// Отримує сховище університету.
        /// </summary>
        IUniversityBll UniversityRepository { get; }

        /// <summary>
        /// Отримує сховища користувачів.
        /// </summary>
        IUserBll UserRepository { get; }

        /// <summary>
        /// Отримує сховище роботодавця.
        /// </summary>
        IEmployerBll EmployerRepository { get; }

        /// <summary>
        /// Отримує візового репозиторій.
        /// </summary>
        IVisaBll VisaRepository { get; }

        /// <summary>
        /// Отримує репозитария рейтингу.
        /// </summary>
        IRateBll RateRepositary { get; }
    }
}