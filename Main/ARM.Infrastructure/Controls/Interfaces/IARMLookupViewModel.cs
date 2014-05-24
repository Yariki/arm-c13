using System;
using System.Collections.Generic;
using System.Windows.Input;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Data.Models;

namespace ARM.Infrastructure.Controls.Interfaces
{
    /// <summary>
    /// Базовий інтерфейс для пошукових моделей представлення.
    /// </summary>
    public interface IARMLookupViewModel : IARMViewModel
    {
        /// <summary>
        /// Дані для сітки.
        /// </summary>
        IEnumerable<object> Source { get; }
        /// <summary>
        /// Повертає тип моделі даних
        /// </summary>
        eARMMetadata Metadata { get; }
        /// <summary>
        /// Повертає тип моделі даних
        /// </summary>
        Type EntityType { get; }
        /// <summary>
        /// Отримує  або задає вибраний елемент.
        /// </summary>
        BaseModel SelectedItem { get; set; }
        /// <summary>
        /// Ініціалізує вказаними метаданими.
        /// </summary>
        /// <param name="metadata">Метадата.</param>
        void Initialize(eARMMetadata metadata);
        /// <summary>
        /// Команда для створення обєкту обраного типу.
        /// </summary>
        ICommand AddEntityCommand { get; }
        /// <summary>
        /// Викликається при відміні вводу.
        /// </summary>
        event EventHandler Cancel;

        /// <summary>
        /// ОТримує шлях до зображення.
        /// </summary>
        string ImagePath { get; }
    }
}