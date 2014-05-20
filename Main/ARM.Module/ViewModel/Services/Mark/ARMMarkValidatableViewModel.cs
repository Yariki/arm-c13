using System;
using System.Collections.Generic;
using System.Windows.Input;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Helpers;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Services.Mark.View;
using ARM.Module.Interfaces.Services.Mark.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Services.Mark
{
    public class ARMMarkValidatableViewModel : ARMValidatableViewModelBase, IARMMarkValidatableViewModel
    {
        public ARMMarkValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMMarkView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            OkCommand = new ARMRelayCommand(OkExecute, CanOkExecute);
        }

        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Mark); }
        }

        public ICommand OkCommand { get; private set; }

        public bool Validate()
        {
            return ValidateBeforeSave();
        }

        #region [properties]

        public IUnityContainer DiContainer
        {
            get { return UnityContainer; }
        }

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public Guid? StudentId
        {
            get { return Get(() => StudentId); }
            set { Set(() => StudentId, value); }
        }

        public Guid? ClassId
        {
            get { return Get(() => ClassId); }
            set { Set(() => ClassId, value); }
        }

        public DateTime? Date
        {
            get { return Get(() => Date); }
            set { Set(() => Date, value); }
        }

        public MarkType Type
        {
            get { return Get(() => Type); }
            set { Set(() => Type, value); }
        }

        public decimal MarkRate
        {
            get { return Get(() => MarkRate); }
            set { Set(() => MarkRate, value); }
        }

        public bool IsCertification
        {
            get { return Get(() => IsCertification); }
            set { Set(() => IsCertification, value); }
        }

        #endregion

        #region [enum source]

        private Dictionary<MarkType, string> _sourceMarkType;
        public Dictionary<MarkType, string> SourceMarkType
        {
            get { return _sourceMarkType ?? (_sourceMarkType = ARMEnumHelper.Instance.GetLocalsForEnum<MarkType>()); }
        }

        #endregion

        #region [override]

        public override void SetBusinessObject(ViewMode mode, eARMMetadata metadata, Guid id, bool isIdEmpty = false)
        {
            base.SetBusinessObject(mode, metadata, id, isIdEmpty);
            var entity = GetBusinessObject<ARM.Data.Models.Mark>();
            if (entity == null)
                return;
            switch (Mode)
            {
                case ViewMode.Add:
                    entity.Date = DateTime.Now.Date;
                    break;
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

        public void SetStudent(Guid? id)
        {
            StudentId = id;
        }

        public void SetClass(Guid? id)
        {
            ClassId = id;
        }
    }
}