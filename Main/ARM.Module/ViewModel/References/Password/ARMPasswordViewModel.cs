using System;
using System.Windows.Input;
using System.Windows.Media;
using ARM.Core.Extensions;
using ARM.Core.Interfaces;
using ARM.Infrastructure.Controls.Interfaces;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.References.ViewModel.Password;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.References.Password
{
    /// <summary>
    /// Клас містить функціональність для роботи з паролями.
    /// </summary>
    public class ARMPasswordViewModel : ARMDataViewModelBase,IARMPasswordViewModel, IARMDialogViewModel
    {
        private bool _hasErrors;

        private readonly SolidColorBrush errorBrush = new SolidColorBrush(Colors.OrangeRed);
        private readonly SolidColorBrush withoutErrorBrush = new SolidColorBrush(Colors.LimeGreen);



        /// <summary>
        /// Створити екземпляр ARMPasswordViewModel.
        /// </summary>
        /// <param name="regionManager">Менеджер регіонів.</param>
        /// <param name="unityContainer">Контейнер IoC.</param>
        /// <param name="eventAggregator">Агрегатор подій.</param>
        /// <param name="view">Користувацький інтерфейс.</param>
        public ARMPasswordViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            OkCommand = new ARMRelayCommand(OnExecute,OnCanExecute);        
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return Resource.AppResource.Resources.Model_User_Password; }
        }

        #region [properties]

        /// <summary>
        /// Отримує або задає перший варіант пароля.
        /// </summary>
        public string Password1
        {
            get { return Get(() => Password1); }
            set
            {
                Set(() => Password1, value); 
                CheckPasswords();
            }
        }

        /// <summary>
        /// Отримує аббо задає повтор пароля.
        /// </summary>
        public string Password2
        {
            get { return Get(() => Password2); }
            set
            {
                Set(() => Password2, value); 
                CheckPasswords();
            }
        }

        /// <summary>
        /// Отримує  або задає значення індикатору. Показує чи валідні паролі.
        /// </summary>
        public SolidColorBrush Indicator
        {
            get { return Get(() => Indicator); }
            set { Set(() => Indicator, value); }
        }

        #endregion

        /// <summary>
        /// Повертає повідомлення про помилку для властивості із заданим ім'ям.
        /// </summary>
        /// <param name="columnName">Колонка.</param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                if (columnName == ARMReflectionExtensions.GetPropertyName(() => Password1)  && string.IsNullOrEmpty(Password1))
                {
                    return "Password couldn't be empty!";
                }
                if (columnName == ARMReflectionExtensions.GetPropertyName(() => Password2) &&
                    string.IsNullOrEmpty(Password2))
                {
                    return "Password couldn't be empty!";
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Отримує повідомлення про помилку, яке вказує, що сталося з цим об'єктом.
        /// </summary>
        public string Error 
        {
            get { return string.Empty; }
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
            return !_hasErrors;
        }

        private bool OnCanExecute(object o)
        {
            return !_hasErrors;
        }

        private void OnExecute(object o)
        {

        }

        /// <summary>
        /// перевірка паролей.
        /// </summary>
        private void CheckPasswords()
        {
            if (string.IsNullOrEmpty(Password1) || string.IsNullOrEmpty(Password2))
            {
                _hasErrors = true;
            }
            else
                _hasErrors = Password1 != Password2;
            Indicator = _hasErrors ? errorBrush : withoutErrorBrush;
        }
    }
}