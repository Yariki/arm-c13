using System;
using System.Windows.Input;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Login.View;
using ARM.Module.Interfaces.Login.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Login
{
    public class ARMLoginViewModel : ARMValidatableViewModelBase,IARMLoginViewModel
    {
        private User _user;

        public ARMLoginViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMLoginView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            OkCommand = new ARMRelayCommand(OnOkExecute,CanOkExecute);
        }

        public override string Title
        {
            get { return "LOGIN"; }
        }

        #region [implentations]
        public ICommand OkCommand { get; private set; }

        public bool Validate()
        {
            return ValidateBeforeSave();
        }

        public Action<bool> CloseAction { get; set; }

        public bool IsUserValid { get; private set; }

        public User GetUser()
        {
            return _user;
        }

        public eARMSystemLanguage Language { get; private set; }
        #endregion

        #region [properties]

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public string Password
        {
            get { return Get(() => Password); }
            set { Set(() => Password, value); }
        }

        public bool IsSaveInfo
        {
            get { return Get(() => IsSaveInfo); }
            set { Set(() => IsSaveInfo, value); }
        }

        #endregion

        #region [overrides]

        public override void SetBusinessObject(ViewMode mode, eARMMetadata metadata, object data)
        {
            base.SetBusinessObject(mode,metadata,data);
            IsValid = false;
        }

        protected override void CancelExecute(object arg)
        {
            CloseDialog(false);
        }

        #endregion

        #region [private]

        private void OnOkExecute(object arg)
        {
            var loginInfo = GetBusinessObject<ARM.Data.Models.Login>();
            var validUser = UnitOfWork.UserRepository.GetValidUser(loginInfo.Name, loginInfo.Password);
            if (validUser != null)
            {
                IsUserValid = true;
                Language = validUser.Language;
                _user = validUser;
                CloseDialog(true);
            }
            else
            {
                Name = Password = string.Empty;
                ARMSystemFacade.Instance.MessageBox.ShowWarning("System couldn't find the valid user according yours 'Username' and 'Password'.\nOr user is not active.");
            }
        }

        private bool CanOkExecute(object arg)
        {
            return IsValid;
        }

        private void CloseDialog(bool result)
        {
            if (CloseAction != null)
            {
                CloseAction(result);
            }
        }

        #endregion

    }
}