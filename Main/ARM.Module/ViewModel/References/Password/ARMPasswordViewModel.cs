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
        public ARMPasswordViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Model_User_Password; }
        }

        #region [properties]

        public string Password1
        {
            get { return Get(() => Password1); }
            set { Set(() => Password1, value); }
        }

        public string Password2
        {
            get { return Get(() => Password2); }
            set { Set(() => Password2, value); }
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
                if ( ( columnName == ARMReflectionExtensions.GetPropertyName(() => Password1) || columnName == ARMReflectionExtensions.GetPropertyName(() => Password2) ) && Password1 != Password2)
                {
                    return "Password should be equal";
                }
                return string.Empty;
            }
        }

        public string Error 
        {
            get { return string.Empty; }
        }
        
    }
}