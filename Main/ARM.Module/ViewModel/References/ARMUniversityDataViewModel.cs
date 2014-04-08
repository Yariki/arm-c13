using System;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Data.UnitOfWork.Implementation;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References
{
    public class ARMUniversityDataViewModel : ARMDataViewModelBase, IARMUniversityDataViewModel
    {
        protected ARMUniversityDataViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {

        }

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public Guid? StaffId
        {
            get { return Get(() => StaffId); }
            set { Set(() => StaffId, value); }
        }

        public string Url
        {
            get { return Get(() => Url); }
            set { Set(() => Url, value); }
        }

        public string Email
        {
            get { return Get(() => Email); }
            set { Set(() => Email, value); }
        }

        protected override void SaveExecute(object arg)
        {
            using (IUnitOfWork unitOfWork = UnityContainer.Resolve<IUnitOfWork>())
            {
                var universityRepositary = unitOfWork.UniversityRepository;
                switch (Mode)
                {
                    case ViewMode.Add:
                        universityRepositary.Insert(GetBusinessObject<University>());
                        universityRepositary.Save();
                        break;
                    case ViewMode.Edit:
                        universityRepositary.Update(GetBusinessObject<University>());
                        universityRepositary.Save();
                        break;
                }

            }
        }
    }
}