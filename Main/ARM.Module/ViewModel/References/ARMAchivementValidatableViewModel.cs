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
    /// <summary>
    /// Клас для роботи з моделю даних - досягнення.
    /// </summary>
    public class ARMAchivementValidatableViewModel : ARMValidatableViewModelBase, IARMAchivementValidatableViewModel
    {
        /// <summary>
        /// Створити екземпляр <see cref="ARMAchivementValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMAchivementValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMAchivementView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            OkCommand = new ARMRelayCommand(OkExecute,CanOkExecute);
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Achivement); }
        }

        /// <summary>
        /// Отримує команду ОК.
        /// </summary>
        public ICommand OkCommand { get; private set; }

        /// <summary>
        /// Перевіряє цей екземпляр.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Отримує або задає дані для типів досягнень.
        /// </summary>
        public Dictionary<AchivementType, string> SourceAchivemetnSource
        {
            get
            {
                return _sourceAchivemetnSource ??
                       (_sourceAchivemetnSource = ARMEnumHelper.Instance.GetLocalsForEnum<AchivementType>());
            }
        }

        #endregion

        #region [private]

        /// <summary>
        /// Виконується при натисканні на кнопку ОК.
        /// </summary>
        /// <param name="arg">аргументи.</param>
        private void OkExecute(object arg)
        {
            
        }

        /// <summary>
        /// Визначає чи доступна команда на виконання.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        /// <returns></returns>
        private bool CanOkExecute(object arg)
        {
            return true;
        }


        #endregion

    }
}