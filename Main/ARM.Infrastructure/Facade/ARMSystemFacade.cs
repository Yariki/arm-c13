using System;
using ARM.Core.Interfaces;
using ARM.Core.Logging;
using ARM.Data.Models;
using ARM.Infrastructure.Interfaces;
using ARM.Infrastructure.Utils;

namespace ARM.Infrastructure.Facade
{
    /// <summary>
    /// Простір імен класу-фасаду для аплікації.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }

    /// <summary>
    /// Загальний класс доступу до підсистем:
    /// 1. Підсистема повідомлень.
    /// 2. Підсистема логування.
    /// 3. Поточний користувач, який працює з програмою.
    /// </summary>
    public class ARMSystemFacade : IARMFacade
    {
        private IARMMessageBoxFacade _messageBoxFacade;

        /// <summary>
        /// Запобігає примірник за замовчуванням на <see класу cref="ARMSystemFacade"/> від створюються.
        /// </summary>
        private ARMSystemFacade()
        {
            _messageBoxFacade = new ARMMessageFacade();
        }

        #region [static]

        private static Lazy<IARMFacade> _instance = new Lazy<IARMFacade>(() => new ARMSystemFacade());

        /// <summary>
        /// Отримує екземляр класу.
        /// </summary>
        public static IARMFacade Instance
        {
            get { return _instance.Value; }
        }

        #endregion [static]

        #region [systems]

        /// <summary>
        /// Отримує підсистему логування.
        /// </summary>
        public IARMLoggerFacade Logger
        {
            get { return ARMLogger.Instance; }
        }

        /// <summary>
        /// Gets the message boОтримує підсистему повідомлень.
        /// </summary>
        /// <value>
        /// The message box.
        /// </value>
        public IARMMessageBoxFacade MessageBox
        {
            get { return _messageBoxFacade; }
        }

        /// <summary>
        /// оотримує або задає поточного користувача.
        /// </summary>
        public User CurrentUser { get; set; }

        #endregion [systems]
    }
}