using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Controls.ARMDialogWindow;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.Helpers;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using ARM.Module.View.References.Password;
using ARM.Module.ViewModel.References.Password;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    public class ARMUserValidatableViewModel : ARMValidatableViewModelBase, IARMUserValidatableViewModel
    {
        #region [needs]

        private bool _passwordHasBeenChanged = false;

        #endregion

        public ARMUserValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMUserView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            SetPasswordCommand = new DelegateCommand(SetPasswordCommandExecute);
        }

        
        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_User); }
        }

        #region [properties]

        public ICommand SetPasswordCommand { get; private set; }

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public string Email
        {
            get { return Get(() => Email); }
            set { Set(() => Email, value); }
        }

        public string Password
        {
            get { return Get(() => Password); }
            set
            {
                Set(() => Password, value);
                _passwordHasBeenChanged = true;
            }
        }

        public bool IsActive
        {
            get { return Get(() => IsActive); }
            set { Set(() => IsActive, value); }
        }

        public eARMSystemLanguage Language
        {
            get { return Get(() => Language); }
            set { Set(() => Language, value); }
        }

        #endregion

        #region [enum source]

        private Dictionary<eARMSystemLanguage, string> _sourceLang;

        public Dictionary<eARMSystemLanguage, string> SourceLanguage
        {
            get { return _sourceLang ?? (_sourceLang = ARMEnumHelper.Instance.GetLocalsForEnum<eARMSystemLanguage>()); }
        }

        #endregion

        #region [override]

        protected override void SaveExecute(object arg)
        {
            if (!ValidateBeforeSave())
                return;

            try
            {
                using (var unitOfWork = UnityContainer.Resolve<IUnitOfWork>())
                {
                    switch (Mode)
                    {

                        case ViewMode.Add:
                            Password = GetMd5Hash(MD5.Create(), Password);
                            unitOfWork.UserRepository.Insert(GetBusinessObject<User>());
                            break;
                        case ViewMode.Edit:
                            if (_passwordHasBeenChanged)
                            {
                                Password = GetMd5Hash(MD5.Create(), Password);
                            }
                            unitOfWork.UserRepository.Update(GetBusinessObject<User>());
                            break;
                    }
                    unitOfWork.UserRepository.Save();
                }
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }

            base.SaveExecute(arg);
        }

        #endregion

        #region [private]

        private void SetPasswordCommandExecute()
        {
            var passViewModel = new ARMPasswordViewModel(RegionManager, UnityContainer, EventAggregator,
                new ARMPasswordView());
            var dialog = new ARMDialogWindow(passViewModel);
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Password = passViewModel.Password1;
            }
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        #endregion


    }
}