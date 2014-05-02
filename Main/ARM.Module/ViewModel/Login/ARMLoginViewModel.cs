using System;
using System.IO;
using System.IO.IsolatedStorage;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ARM.Module.ViewModel.Login
{
    public class ARMLoginViewModel : ARMValidatableViewModelBase,IARMLoginViewModel
    {
        #region [login info]

        class LoginInfo
        {
            public string Name { get; set; }
            public string Password { get; set; }
            public bool IsSave { get; set; }
        }

        #endregion

        private const string SavedloginInfoFile = "info.json";
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
            var savedLoginInfo = GetSavedLoginInfo();
            if (savedLoginInfo != null)
            {
                Name = savedLoginInfo.Name;
                Password = savedLoginInfo.Password;
                IsSaveInfo = savedLoginInfo.IsSave;
            }
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
                if (IsSaveInfo)
                {
                    SaveLoginInfo(loginInfo.Name,loginInfo.Password,IsSaveInfo);
                }
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

        #region [settings]

        private void SaveLoginInfo(string name, string password, bool isSave)
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(SavedloginInfoFile,FileMode.Create, isoStore))
            {
                var info = new LoginInfo() {Name = name, Password = password,IsSave = isSave};
                string line = JsonConvert.SerializeObject(info, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(line);
                }
            }
        }

        private LoginInfo GetSavedLoginInfo()
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            if (isoStore.FileExists(SavedloginInfoFile))
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(SavedloginInfoFile, FileMode.Open, isoStore))
                {
                    using (StreamReader reader = new StreamReader(isoStream))
                    {
                        string line = reader.ReadToEnd();
                        var loginInfo = JsonConvert.DeserializeObject<LoginInfo>(line);
                        return loginInfo;
                    }
                }               
            }
            return null;
        }


        #endregion

    }
}