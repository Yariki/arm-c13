using System;
using ARM.Core.Enums;
using ARM.Data.Interfaces.Country;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using ARM.Resource.AppResource;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    public class ARMCountryValidatableViewModel : ARMValidatableViewModelBase, IARMCountryValidatableViewModel
    {
        public ARMCountryValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMCountryView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        #region IARMCountryValidatableViewModel Members

        public override string Title
        {
            get { return FormatTitle(Resources.Model_Data_Country); }
        }

        #endregion IARMCountryValidatableViewModel Members

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
            using (var unitOfWork = UnityContainer.Resolve<IUnitOfWork>())
            {
                try
                {
                    ICountryBll countryRepository = unitOfWork.CountryRepository;
                    switch (Mode)
                    {
                        case ViewMode.Add:
                            countryRepository.Insert(GetBusinessObject<Country>());
                            break;

                        case ViewMode.Edit:
                            countryRepository.Update(GetBusinessObject<Country>());
                            break;
                    }
                    countryRepository.Save();
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