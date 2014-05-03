using System.Windows.Input;
using ARM.Core.Interfaces;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    public class ARMHobbyValidatableViewModel : ARMValidatableViewModelBase,IARMHobbyValidatableViewModel
    {
        public ARMHobbyValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMHobbyView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            OkCommand = new ARMRelayCommand(OkExecute, CanOkExecute);
        }

        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Hobby); }
        }

        public ICommand OkCommand { get; private set; }

        public bool Validate()
        {
            return ValidateBeforeSave();
        }

        #region [properties]

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public string Note
        {
            get { return Get(() => Note); }
            set { Set(() => Note, value); }
        }

        #endregion

        #region [override]


        #endregion

        #region [private]

        private void OkExecute(object arg)
        {

        }

        private bool CanOkExecute(object arg)
        {
            return true;
        }


        #endregion

    }
}