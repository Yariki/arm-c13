﻿using ARM.Data.Models;
using ARM.Infrastructure.Interfaces.Grid;
using ARM.Infrastructure.MVVM;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Grid
{
    public class ARMCountryGridViewModel  :ARMGridViewModelBase<Country>
    {
        public ARMCountryGridViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMGridView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            
        }

        public override string Title
        {
            get { return Resource.AppResource.Resources.Grid_Country_Title; }
        }
    }
}