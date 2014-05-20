using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ARM.Data.Models;
using ARM.Infrastructure.Facade;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Reports.View;
using ARM.Module.Interfaces.Reports.ViewModel;
using ARM.Module.ViewModel.Reports.Debt;
using ManagedExcel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Xceed.Wpf.DataGrid;
using Application = System.Windows.Application;
using Group = ARM.Data.Models.Group;

namespace ARM.Module.ViewModel.Reports
{
    /// <summary>
    ///     Клас моделі представлення, яка відповідає за функціональність звіту по заборгованості.
    /// </summary>
    public class ARMDebtViewModel : ARMReportViewModelBase, IARMDebtViewModel
    {
        /// <summary>
        ///     Ініціалізує новий екземпляр класу <see cref="ARMDebtViewModel" />.
        /// </summary>
        /// <param name="regionManager">Менеджер регіонів.</param>
        /// <param name="unityContainer">Контейнер IoC.</param>
        /// <param name="eventAggregator">Агрегатор подій.</param>
        /// <param name="view">The view.</param>
        public ARMDebtViewModel(IRegionManager regionManager, IUnityContainer unityContainer,
            IEventAggregator eventAggregator, IARMDebtView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
        }

        #region IARMDebtViewModel Members

        /// <summary>
        ///     Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return Resource.AppResource.Resources.Report_Debt_Title; }
        }

        #endregion IARMDebtViewModel Members

        #region [properties]

        /// <summary>
        ///     Отримує або задає список груп.
        /// </summary>
        public ObservableCollection<Group> Groups
        {
            get { return Get(() => Groups); }
            set { Set(() => Groups, value); }
        }

        /// <summary>
        ///     Отримує або задає обрану групу.
        /// </summary>
        public Group SelectedGroup
        {
            get { return Get(() => SelectedGroup); }
            set { Set(() => SelectedGroup, value); }
        }

        /// <summary>
        ///     Отримує або задає дату початку періоду вибірки.
        /// </summary>
        public DateTime StartDate
        {
            get { return Get(() => StartDate); }
            set { Set(() => StartDate, value); }
        }

        /// <summary>
        ///     Отримує або задає дату закінчення періоду вибірки.
        /// </summary>
        public DateTime FinishDate
        {
            get { return Get(() => FinishDate); }
            set { Set(() => FinishDate, value); }
        }

        /// <summary>
        /// Отримує команду для запуску формування звіту.
        /// </summary>
        public ICommand RunCommand { get; private set; }

        /// <summary>
        /// Отримує або задає дані для відображення в звіті.
        /// </summary>
        public ObservableCollection<ARMStudentDebtDetails> DataSource
        {
            get { return Get(() => DataSource); }
            set { Set(() => DataSource, value); }
        }

        #endregion [properties]

        #region [override]

        /// <summary>
        /// Проводить ініціалізацію вкладки і моделі представлення вцілому.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            Groups = new ObservableCollection<Group>(UnitOfWork.GroupRepository.GetAll());
            RunCommand = new ARMRelayCommand(RunExecute, CanRunExecute);
            ApplyDates();
        }


        /// <summary>
        /// Визначає, чи є цей екземпляр [може експортувати виконати] зазначений аргумент.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        /// <returns></returns>
        protected override bool CanExportExecute(object arg)
        {
            return base.CanExportExecute(arg) && DataSource != null && DataSource.Count > 0;
        }

        /// <summary>
        /// Створює заголовки.
        /// </summary>
        /// <param name="sheet">Лист.</param>
        /// <returns></returns>
        protected override int GenerateHeaders(Worksheet sheet)
        {
            int row = 1;

            SheetManipulator.SetSheetCellValue(sheet, row, 1, Resource.AppResource.Resources.Model_Group_Title);
            SheetManipulator.SetSheetCellValue(sheet, row, 2, SelectedGroup.Name);

            row++;
            SheetManipulator.SetSheetCellWidth(sheet, row, 1, 25);
            SheetManipulator.SetSheetCellValue(sheet, row, 1, Resource.AppResource.Resources.Model_Student_Title);

            SheetManipulator.SetSheetCellWidth(sheet, row, 2, 25);
            SheetManipulator.SetSheetCellValue(sheet, row, 2, Resource.AppResource.Resources.Model_Contract_Title);

            SheetManipulator.SetSheetCellWidth(sheet, row, 3, 25);
            SheetManipulator.SetSheetCellValue(sheet, row, 3, Resource.AppResource.Resources.Model_Contract_Price);

            SheetManipulator.SetSheetCellWidth(sheet, row, 4, 25);
            SheetManipulator.SetSheetCellValue(sheet, row, 4, Resource.AppResource.Resources.UI_Debt);

            return ++row;
        }

        /// <summary>
        /// Заповнення листа даними при еспорті.
        /// </summary>
        /// <param name="sheet">Лист.</param>
        /// <param name="rowStart">Номер рідка, з якого потрібно почитнати заповнення.</param>
        protected override void FillSheet(Worksheet sheet, int rowStart)
        {
            int current = 0;

            foreach (var armStudentDebtDetailse in DataSource)
            {
                SheetManipulator.SetSheetCellValue(sheet, rowStart, 1, armStudentDebtDetailse.Student.Display);

                SheetManipulator.SetSheetCellValue(sheet, rowStart, 2, armStudentDebtDetailse.Contract.ToString());

                SheetManipulator.SetSheetCellValue(sheet, rowStart, 3, armStudentDebtDetailse.Cost);

                SheetManipulator.SetSheetCellValue(sheet, rowStart, 4, armStudentDebtDetailse.Debt);
                rowStart++;
                current++;
                UpdateProgress(current,DataSource.Count);
            }
        }

        #endregion [override]

        #region [private]

        /// <summary>
        /// Запуск звіту на виконання.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        private void RunExecute(object arg)
        {
            if (DataSource != null)
            {
                DataSource.Clear();
            }
            IsBusy = true;
            Task.Factory.StartNew(InternalProcessDebt);
        }

        /// <summary>
        /// Обробка даних звіту по заборгованості в окремому потоці.
        /// </summary>
        private void InternalProcessDebt()
        {
            try
            {
                var data = new ObservableCollection<ARMStudentDebtDetails>();
                IEnumerable<Student> students = SelectedGroup.Students.Where(s => s.StudyType == eARMStudyType.Contract);
                IEnumerable<Contract> contracts =
                    UnitOfWork.ContractRepository.GetContractsByStudent(students.Select(s => s.Id));

                foreach (Contract contract in contracts)
                {
                    IEnumerable<Invoice> invoices =
                        UnitOfWork.InvoiseRepository.GetInvoicesByContractAndPeriod(contract.Id, StartDate,
                            FinishDate);
                    IEnumerable<Payment> payments =
                        UnitOfWork.PaymentRepository.GetInvoicesPayments(invoices.Select(i => i.Id));
                    decimal sumAll = payments.Sum(p => p.Sum);
                    if (sumAll < contract.Price)
                    {
                        var st = SelectedGroup.Students.FirstOrDefault(s => s.Id == contract.StudentId);
                        data.Add(new ARMStudentDebtDetails
                        {
                            Student = st,
                            Contract = contract,
                            Cost = contract.Price,
                            Debt = contract.Price - sumAll
                        });
                    }
                }
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    DataSource = data;
                    IsBusy = false;
                }));
            }
            catch (Exception ex)
            {
                ARMSystemFacade.Instance.Logger.LogError(ex.Message);
                IsBusy = false;
            }
        }

        /// <summary>
        /// Визначає, чи може команда бути виконана.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        /// <returns></returns>
        private bool CanRunExecute(object arg)
        {
            return SelectedGroup != null;
        }


        private void ApplyDates()
        {
            StartDate = new DateTime(DateTime.Now.Year - 1 ,9,1);
            FinishDate = new DateTime(DateTime.Now.Year,5,31);
        }

        #endregion [private]
    }
}