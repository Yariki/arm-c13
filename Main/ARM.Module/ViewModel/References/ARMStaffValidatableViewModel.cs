using System.Collections.Generic;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Helpers;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    public class ARMStaffValidatableViewModel : ARMValidatableViewModelBase, IARMStaffValidatableViewModel
    {
        public ARMStaffValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMStaffView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get
            {
                return string.Format(Resource.AppResource.Resources.Model_Data_Staff,
                    Mode == ViewMode.Add
                        ? Resource.AppResource.Resources.Model_Action_Add
                        : Mode == ViewMode.Edit
                            ? Resource.AppResource.Resources.Model_Action_Edit
                            : Mode == ViewMode.View ? Resource.AppResource.Resources.Model_Action_View : "");
            } 
        }

        #region [model properties]

        public string FirstName
        {
            get { return Get(() => FirstName); }
            set { Set(() => FirstName, value); }
        }

        public string MiddleName
        {
            get
            {
                return Get(() => MiddleName);
            }
            set
            {
                Set(() => MiddleName, value);
            }
        }

        public string LastName
        {
            get { return Get(() => LastName); }

            set
            {
                Set(() => LastName, value);
            }
        }

        public string Email
        {
            get { return Get(() => Email); }
            set {Set(() => Email,value);}
        }

        public string PhoneMobile 
        {
            get { return Get(() => PhoneMobile); }
            set { Set(() => PhoneMobile,value);}
        }

        public string PhoneHome
        {
            get { return Get(() => PhoneHome); }
            set { Set(() => PhoneHome,value);}
        }

        public SexType Sex
        {
            get { return Get(() => Sex); }
            set { Set(() => Sex,value);}
        }

        public StaffType StaffType
        {
            get { return Get(() => StaffType); }
            set { Set(() => StaffType, value); }
        }

        #endregion

        #region [enum resources]

        private Dictionary<SexType, string> _sourceSex;
        public Dictionary<SexType, string> SourceSex
        {
            get { return _sourceSex ?? (_sourceSex = EnumHelper.Instance.GetLocalsForEnum<SexType>()); }
        }

        private Dictionary<StaffType, string> _sourceStaff;
        public Dictionary<StaffType,string> SourceStaff 
        {
            get { return _sourceStaff ?? (_sourceStaff = EnumHelper.Instance.GetLocalsForEnum<StaffType>()); }
        }

        #endregion

        protected override bool CanSaveExecte(object arg)
        {
            System.Diagnostics.Debug.WriteLine(IsValid);
            return IsValid;
        }

        protected override void SaveExecute(object arg)
        {
            ValidateBeforeSave();
            if(!IsValid)
                return;
            
            using (IUnitOfWork unitOfWork = UnityContainer.Resolve<IUnitOfWork>() )
            {
                var staffRepository = unitOfWork.StaffRepository;
                switch (Mode)
                {
                    case ViewMode.Add:
                        staffRepository.Insert(GetBusinessObject<Staff>());
                        staffRepository.Save();
                        break;
                    case  ViewMode.Edit:
                        staffRepository.Update(GetBusinessObject<Staff>());
                        staffRepository.Save();
                        break;
                }
            }
            base.SaveExecute(arg);
        }
    }
}