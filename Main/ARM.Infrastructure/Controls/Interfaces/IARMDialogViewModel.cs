using System.Windows.Input;
using ARM.Core.Interfaces;

namespace ARM.Infrastructure.Controls.Interfaces
{
    /// <summary>
    /// Простір імен загальних інтерфейсів для моделей представлення.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }

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