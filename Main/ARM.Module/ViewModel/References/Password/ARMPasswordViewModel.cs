using System;
using System.Windows.Input;
using System.Windows.Media;
using ARM.Core.Extensions;
using ARM.Core.Interfaces;
using ARM.Infrastructure.Controls.Interfaces;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.ViewModel.Password;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References.Password
{
    public class ARMPasswordViewModel : ARMDataViewModelBase,IARMPasswordViewModel, IARMDialogViewModel
    {
        private bool _hasErrors;

        private readonly SolidColorBrush errorBrush = new SolidColorBrush(Colors.OrangeRed);
        private readonly SolidColorBrush withoutErrorBrush = new SolidColorBrush(Colors.LimeGreen);



        public ARMPasswordViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            OkCommand = new ARMRelayCommand(OnExecute,OnCanExecute);        
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Model_User_Password; }
        }

        #region [properties]

        public string Password1
        {
            get { return Get(() => Password1); }
            set
            {
                Set(() => Password1, value); 
                CheckPasswords();
            }
        }

        public string Password2
        {
            get { return Get(() => Password2); }
            set
            {
                Set(() => Password2, value); 
                CheckPasswords();
            }
        }

        public SolidColorBrush Indicator
        {
            get { return Get(() => Indicator); }
            set { Set(() => Indicator, value); }
        }

        #endregion

        public string this[string columnName]
        {
            get
            {
                if (columnName == ARMReflectionExtensions.GetPropertyName(() => Password1)  && string.IsNullOrEmpty(Password1))
                {
                    return "Password couldn't be empty!";
                }
                if (columnName == ARMReflectionExtensions.GetPropertyName(() => Password2) &&
                    string.IsNullOrEmpty(Password2))
                {
                    return "Password couldn't be empty!";
                }
                return string.Empty;
            }
        }

        public string Error 
        {
            get { return string.Empty; }
        }

        public ICommand OkCommand { get; private set; }
        public bool Validate()
        {
            return !_hasErrors;
        }

        private bool OnCanExecute(object o)
        {
            return !_hasErrors;
        }

        private void OnExecute(object o)
        {

        }

        private void CheckPasswords()
        {
            if (string.IsNullOrEmpty(Password1) || string.IsNullOrEmpty(Password2))
            {
                _hasErrors = true;
            }
            else
                _hasErrors = Password1 != Password2;
            Indicator = _hasErrors ? errorBrush : withoutErrorBrush;
        }
    }
}