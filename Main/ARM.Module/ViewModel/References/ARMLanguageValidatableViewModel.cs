using System;
using ARM.Core.Enums;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    public class ARMLanguageValidatableViewModel : ARMValidatableViewModelBase, IARMLanguageValidatableViewModel
    {
        public ARMLanguageValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMLanguageView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Language); }
        }

        #region [properties]

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        #endregion [properties]

        protected override void SaveExecute(object arg)
        {
            ValidateBeforeSave();
            if (!IsValid)
                return;

            using (IUnitOfWork unitOfWork = UnityContainer.Resolve<IUnitOfWork>())
            {
                try
                {
                    var languageRepository = unitOfWork.LanguageRepository;
                    switch (Mode)
                    {
                        case ViewMode.Add:
                            languageRepository.Insert(GetBusinessObject<Language>());
                            break;

                        case ViewMode.Edit:
                            languageRepository.Update(GetBusinessObject<Language>());
                            break;
                    }
                    languageRepository.Save();
                }
                catch (Exception ex)
                {
                    ARMSystemFacade.Instance.Logger.LogError(ex.Message);
                }
            }

            base.SaveExecute(arg);
        }
    }
}