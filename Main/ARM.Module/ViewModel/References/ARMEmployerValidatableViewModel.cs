﻿using System;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.View;
using ARM.Module.Interfaces.References.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    public class ARMEmployerValidatableViewModel : ARMValidatableViewModelBase, IARMEmployerValidatableViewModel
    {
        public ARMEmployerValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMEmployerView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Employer); }
        }

        #region [properties]

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public string Contact
        {
            get { return Get(() => Contact); }
            set { Set(() => Contact, value); }
        }

        public string Phone
        {
            get { return Get(() => Phone); }
            set { Set(() => Phone, value); }
        }

        public string Email
        {
            get { return Get(() => Email); }
            set { Set(() => Email, value); }
        }

        public string Url
        {
            get { return Get(() => Url); }
            set { Set(() => Url, value); }
        }


        #endregion

        #region [overrides]

        protected override void SaveExecute(object arg)
        {
            if (!ValidateBeforeSave())
                return;
            try
            {
                switch (Mode)
                {
                    case ViewMode.Add:
                        UnitOfWork.EmployerRepository.Insert(GetBusinessObject<Employer>());
                        break;
                    case ViewMode.Edit:
                        UnitOfWork.EmployerRepository.Update(GetBusinessObject<Employer>());
                        break;
                }
                UnitOfWork.EmployerRepository.Save();
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
            }

            base.SaveExecute(arg);
        }

        #endregion

        #region [enum source]
        #endregion

        #region [private]
        #endregion

    }
}