using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.MVVM;
using ARM.Module.Helpers.AttachedProperty;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Reports
{
    /// <summary>
    /// Базовий класс для формування звітів, які залежать від групи та сесії.
    /// </summary>
    public abstract class ARMReportGroupSessionViewModelBase : ARMReportViewModelBase
    {
        /// <summary>
        /// Створити екземпляр ARMReportGroupSessionViewModelBase.
        /// </summary>
        /// <param name="regionManager">Менеджер регіонів.</param>
        /// <param name="unityContainer">Контейнер IoC.</param>
        /// <param name="eventAggregator">Агрегатор подій.</param>
        /// <param name="view">The view.</param>
        protected ARMReportGroupSessionViewModelBase(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMView view) 
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        /// <summary>
        /// Проводить ініціалізацію вкладки і моделі представлення вцілому.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            Groups = new ObservableCollection<Group>(UnitOfWork.GroupRepository.GetAllWithRelated());
            Sessions = new ObservableCollection<Session>(UnitOfWork.SessionRepository.GetAll());
            SelectedGroup = null;
            SelectedSession = null;
        }

        /// <summary>
        /// Отримує або задає список груп.
        /// </summary>
        public ObservableCollection<Group> Groups
        {
            get { return Get(() => Groups); }
            set { Set(() => Groups, value); }
        }

        /// <summary>
        /// Отримує або задає список сесій.
        /// </summary>
        public ObservableCollection<Session> Sessions
        {
            get { return Get(() => Sessions); }
            set { Set(() => Sessions, value); }
        }

        /// <summary>
        /// Отримує або задає обрану групу.
        /// </summary>
        public Group SelectedGroup
        {
            get { return Get(() => SelectedGroup); }
            set { Set(() => SelectedGroup, value); }
        }

        /// <summary>
        /// Отримує або задає обрану сесію.
        /// </summary>
        public Session SelectedSession
        {
            get { return Get(() => SelectedSession); }
            set { Set(() => SelectedSession, value); }
        }

        /// <summary>
        /// Отримує або задаю список колонок для сітки.
        /// </summary>
        public ObservableCollection<DataGridColumn> Columns
        {
            get { return Get(() => Columns); }
            set { Set(() => Columns, value); }
        }

        /// <summary>
        /// генерація колонок
        /// </summary>
        protected virtual void GenerateColumns(IEnumerable<Guid> listClasses)
        {
            var col = new ObservableCollection<DataGridColumn>();
            var name = new DataGridTextColumn() { Width = 200, Header = Resource.AppResource.Resources.Model_Student_Title };
            name.Binding = new Binding("Student.Display") { Mode = BindingMode.OneTime };
            name.CanUserSort = false;
            col.Add(name);
            foreach (var source in SelectedSession.Classes.Where(c => listClasses.Contains(c.Id)).OrderBy(c => c.Id))
            {
                var c = new DataGridTemplateColumn() { Width = 150, Header = source.Name };
                c.SetValue(ARMDataGridTemplateColumnBinding.ColumnBindingProperty, string.Format("[{0}]", source.Id.ToString().ToLower()));
                col.Add(c);
            }
            Columns = col;
        }
    }
}