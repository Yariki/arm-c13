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
    /// <summary>
    /// Клас відповідає за роботу при вході в систему, за збереження та відтворення інформації про останій логін, перевірку правильноссті введеної інформації.
    /// </summary>
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

        /// <summary>
        /// Створити екземпляр <see cref="ARMLoginViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMLoginViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMLoginView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            OkCommand = new ARMRelayCommand(OnOkExecute,CanOkExecute);
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return "LOGIN"; }
        }

        #region [implentations]
        /// <summary>
        /// Отримує команду ОК.
        /// </summary>
        public ICommand OkCommand { get; private set; }

        /// <summary>
        /// Перевіряє цей екземпляр.
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return ValidateBeforeSave();
        }

        /// <summary>
        /// Отримує або зажаю дію закриття.
        /// </summary>
        public Action<bool> CloseAction { get; set; }

        /// <summary>
        /// Отримує або задає валідність користувача.
        /// </summary>
        public bool IsUserValid { get; private set; }

        /// <summary>
        /// Повертає поточного користувача.
        /// </summary>
        /// <returns></returns>
        public User GetUser()
        {
            return _user;
        }

        /// <summary>
        /// Отримує поточну мову користувача.
        /// </summary>
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

        /// <summary>
        /// втсановлення режиму роботи та моделі даних
        /// </summary>
        /// <param name="mode">Режим.</param>
        /// <param name="metadata">Метадата.</param>
        /// <param name="data">Модель даних.</param>
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

        /// <summary>
        /// Виклик методу відміни.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        protected override void CancelExecute(object arg)
        {
            CloseDialog(false);
        }

        #endregion

        #region [private]

        /// <summary>
        /// Викликається при натисканні на кнопку ОК.
        /// </summary>
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

        /// <summary>
        /// Визначає чи доступна кнопка ОК.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private bool CanOkExecute(object arg)
        {
            return IsValid;
        }

        /// <summary>
        /// Закриття діалогу.
        /// </summary>
        private void CloseDialog(bool result)
        {
            if (CloseAction != null)
            {
                CloseAction(result);
            }
        }

        #endregion

        #region [settings]

        /// <summary>
        /// Зберігає інформацію про логін.
        /// </summary>
        /// <param name="name">Імя.</param>
        /// <param name="password">Пароль.</param>
        /// <param name="isSave">Флаг, який показує чи потрібно зберігати.</param>
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

        /// <summary>
        /// Отримує попередньо збережену інформацію про логін.
        /// </summary>
        /// <returns></returns>
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