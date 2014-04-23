using System.Collections.Generic;
using System.Windows.Input;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Helpers;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    public class ARMAchivementValidatableViewModel : ARMValidatableViewModelBase, IARMAchivementValidatableViewModel
    {
        public ARMAchivementValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMAchivementView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            OkCommand = new ARMRelayCommand(OkExecute,CanOkExecute);
        }

        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Achivement); }
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

        public AchivementType Type
        {
            get { return Get(() => Type); }
            set { Set(() => Type, value); }
        }

        #endregion

        #region [enum source]

        private Dictionary<AchivementType, string> _sourceAchivemetnSource;

        public Dictionary<AchivementType, string> SourceAchivemetnSource
        {
            get
            {
                return _sourceAchivemetnSource ??
                       (_sourceAchivemetnSource = EnumHelper.Instance.GetLocalsForEnum<AchivementType>());
            }
        }

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