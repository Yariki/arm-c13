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
using ARM.Data.UnitOfWork.Implementation;
using Microsoft.Practices.Unity;

namespace ARM.Data.UnitOfWork.Interfaces
{
    /// <summary>
    /// Реалізація класу дя доступу до всіх репозитаріїв.
    /// З автоматичними знищенням всіх створених, які використовувались на протязі роботи.
    /// </summary>
    public class ARMUnitOfWork : IUnitOfWork
    {
        #region [needs]

        private IAchivementBll _achivementRepository;
        private IAddressBll _addressRepository;
        private IClassBll _classRepository;
        private IContractBll _contractRepository;
        private ICountryBll _countryRepository;
        private IFacultyBll _facultyRepository;
        private IGroupBll _groupRepository;
        private IHobbyBll _hobbyRepository;
        private IInvoiceBll _invoiseRepository;
        private ILanguageBll _languageRepository;
        private IMarkBll _markrepository;
        private IParentBll _parentReposotory;
        private IPaymentBll _paymentrepository;
        private ISessionBll _sessionRepository;
        private ISettingsBll _settingsRepository;
        private ISpecialtyBll _speciltyRepository;
        private IStaffBll _staffRepository;
        private IStudentBll _studentRepository;
        private IUniversityBll _universityRepository;
        private IUserBll _userRepositotry;
        private IEmployerBll _employerRepository;
        private IVisaBll _visaRepository;
        private IRateBll _rateRepository;

        private bool _disposed = false;
        private readonly IUnityContainer _unityContainer;

        #endregion [needs]

        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMUnitOfWork"/>.
        /// </summary>
        /// <param name="unityContainer">Контейнер IoC.</param>
        public ARMUnitOfWork(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        #region [disposable]

        /// <summary>
        /// Виконує визначаються додатком завдання, пов'язані з вивільненням або скиданням некерованих ресурсів.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Звільняє некеровані і - можливо - керовані ресурси.
        /// </summary>
        /// <param name="disposing"><c>true</c> щоб звільнити керовані і некеровані ресурси;<c>false</c> щоб звільнити тільки некеровані ресурси.</param>
        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    DisposeAllAlive();
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// Знищує всі репозитарії, які використовувались.
        /// </summary>
        private void DisposeAllAlive()
        {
            if (_achivementRepository != null)
                _achivementRepository.Dispose();
            if (_addressRepository != null)
                _addressRepository.Dispose();
            if (_classRepository != null)
                _classRepository.Dispose();
            if (_contractRepository != null)
                _contractRepository.Dispose();
            if (_countryRepository != null)
                _countryRepository.Dispose();
            if (_facultyRepository != null)
                _facultyRepository.Dispose();
            if (_groupRepository != null)
                _groupRepository.Dispose();
            if (_hobbyRepository != null)
                _hobbyRepository.Dispose();
            if (_invoiseRepository != null)
                _invoiseRepository.Dispose();
            if (_languageRepository != null)
                _languageRepository.Dispose();
            if (_markrepository != null)
                _markrepository.Dispose();
            if (_parentReposotory != null)
                _parentReposotory.Dispose();
            if (_paymentrepository != null)
                _paymentrepository.Dispose();
            if (_sessionRepository != null)
                _sessionRepository.Dispose();
            if (_settingsRepository != null)
                _settingsRepository.Dispose();
            if (_speciltyRepository != null)
                _speciltyRepository.Dispose();
            if (_staffRepository != null)
                _staffRepository.Dispose();
            if (_studentRepository != null)
                _studentRepository.Dispose();
            if (_universityRepository != null)
                _universityRepository.Dispose();
            if (_userRepositotry != null)
                _userRepositotry.Dispose();
            if (_employerRepository != null)
                _employerRepository.Dispose();
            if (_visaRepository != null)
                _visaRepository.Dispose();
            if (_rateRepository != null)
                _rateRepository.Dispose();
        }

        #endregion [disposable]

        #region [repositories]

        /// <summary>
        /// Отримує сховище Досягнення.
        /// </summary>
        public IAchivementBll AchivementRepository
        {
            get { return _achivementRepository ?? (_achivementRepository = _unityContainer.Resolve<IAchivementBll>()); }
        }

        /// <summary>
        /// Отримує сховище адресу.
        /// </summary>
        public IAddressBll AddressRepository
        {
            get { return _addressRepository ?? (_addressRepository = _unityContainer.Resolve<IAddressBll>()); }
        }

        /// <summary>
        /// Отримує сховище класу.
        /// </summary>
        public IClassBll ClassRepository
        {
            get { return _classRepository ?? (_classRepository = _unityContainer.Resolve<IClassBll>()); }
        }

        /// <summary>
        /// Отримує сховище контракту.
        /// </summary>
        public IContractBll ContractRepository
        {
            get { return _contractRepository ?? (_contractRepository = _unityContainer.Resolve<IContractBll>()); }
        }

        /// <summary>
        /// Отримує сховищ країни.
        /// </summary>
        public ICountryBll CountryRepository
        {
            get { return _countryRepository ?? (_countryRepository = _unityContainer.Resolve<ICountryBll>()); }
        }

        /// <summary>
        /// Отримує сховище факультету.
        /// </summary>
        public IFacultyBll FacultyRepository
        {
            get { return _facultyRepository ?? (_facultyRepository = _unityContainer.Resolve<IFacultyBll>()); }
        }

        /// <summary>
        /// Отримує сховище групи.
        /// </summary>
        public IGroupBll GroupRepository
        {
            get { return _groupRepository ?? (_groupRepository = _unityContainer.Resolve<IGroupBll>()); }
        }

        /// <summary>
        /// Отримує сховище хобі.
        /// </summary>
        public IHobbyBll HobbyRepository
        {
            get { return _hobbyRepository ?? (_hobbyRepository = _unityContainer.Resolve<IHobbyBll>()); }
        }

        /// <summary>
        /// Отримує сховище invoise.
        /// </summary>
        public IInvoiceBll InvoiseRepository
        {
            get { return _invoiseRepository ?? (_invoiseRepository = _unityContainer.Resolve<IInvoiceBll>()); }
        }

        /// <summary>
        /// Отримує сховище мови.
        /// </summary>
        public ILanguageBll LanguageRepository
        {
            get { return _languageRepository ?? (_languageRepository = _unityContainer.Resolve<ILanguageBll>()); }
        }

        /// <summary>
        /// Отримує сховище оцінок.
        /// </summary>
        public IMarkBll MarkRepository
        {
            get { return _markrepository ?? (_markrepository = _unityContainer.Resolve<IMarkBll>()); }
        }

        /// <summary>
        /// Повертає батьківський репозиторій.
        /// </summary>
        public IParentBll ParentRepository
        {
            get { return _parentReposotory ?? (_parentReposotory = _unityContainer.Resolve<IParentBll>()); }
        }

        /// <summary>
        /// Отримує сховище оплати.
        /// </summary>
        public IPaymentBll PaymentRepository
        {
            get { return _paymentrepository ?? (_paymentrepository = _unityContainer.Resolve<IPaymentBll>()); }
        }

        /// <summary>
        /// Отримує сховище сесії.
        /// </summary>
        public ISessionBll SessionRepository
        {
            get { return _sessionRepository ?? (_sessionRepository = _unityContainer.Resolve<ISessionBll>()); }
        }

        /// <summary>
        /// Отримує сховище налаштувань.
        /// </summary>
        public ISettingsBll SettingsRepository
        {
            get { return _settingsRepository ?? (_settingsRepository = _unityContainer.Resolve<ISettingsBll>()); }
        }

        /// <summary>
        /// Отримує сховище спеціальності.
        /// </summary>
        public ISpecialtyBll SpeciltyRepository
        {
            get { return _speciltyRepository ?? (_speciltyRepository = _unityContainer.Resolve<ISpecialtyBll>()); }
        }

        /// <summary>
        /// Отримує сховище персоналу.
        /// </summary>
        public IStaffBll StaffRepository
        {
            get { return _staffRepository ?? (_staffRepository = _unityContainer.Resolve<IStaffBll>()); }
        }

        /// <summary>
        /// Отримує сховище студентів.
        /// </summary>
        public IStudentBll StudentRepository
        {
            get { return _studentRepository ?? (_studentRepository = _unityContainer.Resolve<IStudentBll>()); }
        }

        /// <summary>
        /// Отримує сховище університету.
        /// </summary>
        public IUniversityBll UniversityRepository
        {
            get { return _universityRepository ?? (_universityRepository = _unityContainer.Resolve<IUniversityBll>()); }
        }

        /// <summary>
        /// Отримує сховища користувачів.
        /// </summary>
        public IUserBll UserRepository
        {
            get { return _userRepositotry ?? (_userRepositotry = _unityContainer.Resolve<IUserBll>()); }
        }

        /// <summary>
        /// Отримує сховище роботодавця.
        /// </summary>
        public IEmployerBll EmployerRepository
        {
            get { return _employerRepository ?? (_employerRepository = _unityContainer.Resolve<IEmployerBll>()); }
        }

        /// <summary>
        /// Отримує візового репозиторій.
        /// </summary>
        public IVisaBll VisaRepository
        {
            get { return _visaRepository ?? (_visaRepository = _unityContainer.Resolve<IVisaBll>()); }
        }

        /// <summary>
        /// Отримує репозитария рейтингу.
        /// </summary>
        public IRateBll RateRepositary
        {
            get { return _rateRepository ?? (_rateRepository = _unityContainer.Resolve<IRateBll>()); }
        }

        #endregion [repositories]
    }
}