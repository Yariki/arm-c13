using System.Windows.Input;
using ARM.Core.Interfaces;

namespace ARM.Infrastructure.Controls.Interfaces
{
    /// <summary>
    /// Базовий інтерфейс для моделей представлення діалогових вікон.
    /// </summary>
    public interface IARMDialogViewModel : IARMViewModel
    {
        /// <summary>
        /// Отримує команду ОК.
        /// </summary>
        ICommand OkCommand { get; }

        /// <summary>
        /// Отримує команду скасування.
        /// </summary>
        ICommand CancelCommand { get; }

        /// <summary>
        /// Перевіряє цей екземпляр.
        /// </summary>
        /// <returns></returns>
        bool Validate();
    }
}