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
    /// <summary>
    /// Клас для роботи з моделю даних - хобі.
    /// </summary>
    public class ARMHobbyValidatableViewModel : ARMValidatableViewModelBase,IARMHobbyValidatableViewModel
    {
        /// <summary>
        /// Створити екземпляр <see cref="ARMHobbyValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMHobbyValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMHobbyView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            OkCommand = new ARMRelayCommand(OkExecute, CanOkExecute);
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Hobby); }
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

        #endregion

        #region [override]


        #endregion

        #region [private]

        /// <summary>
        /// Натискання на кнопку ОК.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void OkExecute(object arg)
        {

        }

        /// <summary>
        /// Визначає чи доступна кнопка.
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