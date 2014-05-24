﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Helpers;
using ARM.Infrastructure.MVVM;
using ARM.Module.Interfaces.Services.Mark.View;
using ARM.Module.Interfaces.Services.Mark.ViewModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace ARM.Module.ViewModel.Services.Mark
{
    /// <summary>
    /// Клас для роботи з моделю - оцінка.
    /// </summary>
    public class ARMMarkValidatableViewModel : ARMValidatableViewModelBase, IARMMarkValidatableViewModel
    {
        /// <summary>
        /// Створити екземпляр <see cref="ARMMarkValidatableViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="view">The view.</param>
        public ARMMarkValidatableViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator eventAggregator, IARMMarkView view)
            : base(regionManager, unityContainer, eventAggregator, view)
        {
            OkCommand = new ARMRelayCommand(OkExecute, CanOkExecute);
        }

        /// <summary>
        /// Заголовок вкладки.
        /// </summary>
        public override string Title
        {
            get { return FormatTitle(Resource.AppResource.Resources.Model_Data_Mark); }
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

        public IUnityContainer DiContainer
        {
            get { return UnityContainer; }
        }

        public string Name
        {
            get { return Get(() => Name); }
            set { Set(() => Name, value); }
        }

        public Guid? StudentId
        {
            get { return Get(() => StudentId); }
            set { Set(() => StudentId, value); }
        }

        public Guid? ClassId
        {
            get { return Get(() => ClassId); }
            set { Set(() => ClassId, value); }
        }

        public DateTime? Date
        {
            get { return Get(() => Date); }
            set { Set(() => Date, value); }
        }

        public MarkType Type
        {
            get { return Get(() => Type); }
            set { Set(() => Type, value); }
        }

        public decimal MarkRate
        {
            get { return Get(() => MarkRate); }
            set { Set(() => MarkRate, value); }
        }

        public bool IsCertification
        {
            get { return Get(() => IsCertification); }
            set { Set(() => IsCertification, value); }
        }

        #endregion

        #region [enum source]

        private Dictionary<MarkType, string> _sourceMarkType;
        /// <summary>
        /// Отримує або задає список значень типів оцінок.
        /// </summary>
        public Dictionary<MarkType, string> SourceMarkType
        {
            get { return _sourceMarkType ?? (_sourceMarkType = ARMEnumHelper.Instance.GetLocalsForEnum<MarkType>()); }
        }

        #endregion

        #region [override]

        /// <summary>
        /// встановлення режиму роботи та моделі даних (у відповідності до метаданих та ідентифікатора)
        /// </summary>
        /// <param name="mode">Режим роботи.</param>
        /// <param name="metadata">Метадата.</param>
        /// <param name="id">Ідентифікатор.</param>
        /// <param name="isIdEmpty">Флаг, чи може фдентифікатор бути пустим.</param>
        public override void SetBusinessObject(ViewMode mode, eARMMetadata metadata, Guid id, bool isIdEmpty = false)
        {
            base.SetBusinessObject(mode, metadata, id, isIdEmpty);
            var entity = GetBusinessObject<ARM.Data.Models.Mark>();
            if (entity == null)
                return;
            switch (Mode)
            {
                case ViewMode.Add:
                    entity.Date = DateTime.Now.Date;
                    break;
            }
        }

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
        /// Визначає чи кнопка ОК досступна.
        /// </summary>
        /// <param name="arg">Аргументи.</param>
        /// <returns></returns>
        private bool CanOkExecute(object arg)
        {
            return true;
        }


        #endregion

        /// <summary>
        /// Вставновити студента.
        /// </summary>
        /// <param name="id">Ідентифікатор.</param>
        public void SetStudent(Guid? id)
        {
            StudentId = id;
        }

        /// <summary>
        /// Встановити клас.
        /// </summary>
        /// <param name="id">Ідентифікатор.</param>
        public void SetClass(Guid? id)
        {
            ClassId = id;
        }
    }
}