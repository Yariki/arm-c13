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
using ARM.Data.UnitOfWork.Implementation;
using Microsoft.Practices.Unity;

namespace ARM.Data.UnitOfWork.Interfaces
{
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

        private bool _disposed = false;
        private readonly IUnityContainer _unityContainer;

        #endregion

        public ARMUnitOfWork(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        #region [disposable]

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

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

        private void DisposeAllAlive()
        {
            if(_achivementRepository !=  null)
                _achivementRepository.Dispose();
            if(_addressRepository != null)
                _addressRepository.Dispose();
            if(_classRepository != null)
                _classRepository.Dispose();
            if(_contractRepository != null)
                _contractRepository.Dispose();
            if(_countryRepository != null)
                _countryRepository.Dispose();
            if(_facultyRepository != null)
                _facultyRepository.Dispose();
            if(_groupRepository != null)
                _groupRepository.Dispose();
            if(_hobbyRepository  !=null)
                _hobbyRepository.Dispose();
            if(_invoiseRepository != null)
                _invoiseRepository.Dispose();
            if(_languageRepository != null)
                _languageRepository.Dispose();
            if(_markrepository != null )
                _markrepository.Dispose();
            if(_parentReposotory != null)
                _parentReposotory.Dispose();
            if(_paymentrepository  != null)
                _paymentrepository.Dispose();
            if(_sessionRepository !=  null)
                _sessionRepository.Dispose();
            if(_settingsRepository != null)
                _settingsRepository.Dispose();
            if(_speciltyRepository != null)
                _speciltyRepository.Dispose();
            if(_staffRepository  != null)
                _staffRepository.Dispose();
            if(_studentRepository != null)
                _studentRepository.Dispose();
            if(_universityRepository != null)
                _universityRepository.Dispose();
        }

        #endregion

        #region [repositories]

        public IAchivementBll AchivementRepository
        {
            get { return _achivementRepository ?? (_achivementRepository = _unityContainer.Resolve<IAchivementBll>()); }
        }

        public IAddressBll AddressRepository
        {
            get { return _addressRepository ?? (_addressRepository = _unityContainer.Resolve<IAddressBll>()); }
        }

        public IClassBll ClassRepository
        {
            get { return _classRepository ?? (_classRepository = _unityContainer.Resolve<IClassBll>()); }
        }

        public IContractBll ContractRepository
        {
            get { return _contractRepository ?? (_contractRepository = _unityContainer.Resolve<IContractBll>()); }
        }

        public ICountryBll CountryRepository
        {
            get { return _countryRepository ?? (_countryRepository = _unityContainer.Resolve<ICountryBll>()); }
        }

        public IFacultyBll FacultyRepository
        {
            get { return _facultyRepository ?? (_facultyRepository = _unityContainer.Resolve<IFacultyBll>()); }
        }

        public IGroupBll GroupRepository
        {
            get { return _groupRepository ?? (_groupRepository = _unityContainer.Resolve<IGroupBll>()); }
        }

        public IHobbyBll HobbyRepository
        {
            get { return _hobbyRepository ?? (_hobbyRepository = _unityContainer.Resolve<IHobbyBll>()); }
        }

        public IInvoiceBll InvoiseRepository
        {
            get { return _invoiseRepository ?? (_invoiseRepository = _unityContainer.Resolve<IInvoiceBll>()); }
        }

        public ILanguageBll LanguageRepository
        {
            get { return _languageRepository ?? (_languageRepository = _unityContainer.Resolve<ILanguageBll>()); }
        }

        public IMarkBll MarkRepository
        {
            get { return _markrepository ?? (_markrepository = _unityContainer.Resolve<IMarkBll>()); }
        }

        public IParentBll ParentReposotory
        {
            get { return _parentReposotory ?? (_parentReposotory = _unityContainer.Resolve<IParentBll>()); }
        }

        public IPaymentBll PaymentRepository
        {
            get { return _paymentrepository ?? (_paymentrepository = _unityContainer.Resolve<IPaymentBll>()); }
        }

        public ISessionBll SessionRepository
        {
            get { return _sessionRepository ?? (_sessionRepository = _unityContainer.Resolve<ISessionBll>()); }
        }

        public ISettingsBll SettingsRepository
        {
            get { return _settingsRepository ?? (_settingsRepository = _unityContainer.Resolve<ISettingsBll>()); }
        }

        public ISpecialtyBll SpeciltyRepository
        {
            get { return _speciltyRepository ?? (_speciltyRepository = _unityContainer.Resolve<ISpecialtyBll>()); }
        }

        public IStaffBll StaffRepository
        {
            get { return _staffRepository ?? (_staffRepository = _unityContainer.Resolve<IStaffBll>()); }
        }

        public IStudentBll StudentRepository
        {
            get { return _studentRepository ?? (_studentRepository = _unityContainer.Resolve<IStudentBll>()); }
        }

        public IUniversityBll UniversityRepository
        {
            get { return _universityRepository ?? (_universityRepository = _unityContainer.Resolve<IUniversityBll>()); }
        }

        #endregion
    }
}