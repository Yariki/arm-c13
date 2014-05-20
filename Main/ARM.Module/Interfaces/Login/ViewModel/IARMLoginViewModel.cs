using System;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Controls.Interfaces;

namespace ARM.Module.Interfaces.Login.ViewModel
{
    /// <summary>
    /// Інтрефейс меделі представлення логіна.
    /// </summary>
    public interface IARMLoginViewModel : IARMValidatableViewModel, IARMDialogViewModel
    {
        /// <summary>
        /// Отримує або зажаю дію закриття.
        /// </summary>
        Action<bool> CloseAction { get; set; }
        /// <summary>
        /// Отримує або задає валідність користувача.
        /// </summary>
        bool IsUserValid { get; }
        /// <summary>
        /// Повертає поточного користувача.
        /// </summary>
        /// <returns></returns>
        User GetUser();
        /// <summary>
        /// Отримує поточну мову користувача.
        /// </summary>
        eARMSystemLanguage Language  {get;}
    }
}