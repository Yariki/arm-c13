using System;
using ARM.Core.Interfaces;
using ARM.Core.Logging;
using ARM.Data.Models;
using ARM.Infrastructure.Interfaces;
using ARM.Infrastructure.Utils;

namespace ARM.Infrastructure.Facade
{
    public class ARMSystemFacade : IARMFacade
    {
        private IARMMessageBoxFacade _messageBoxFacade;

        private ARMSystemFacade()
        {
            _messageBoxFacade = new ARMMessageFacade();
        }

        #region [static]

        private static Lazy<IARMFacade> _instance = new Lazy<IARMFacade>(() => new ARMSystemFacade());

        public static IARMFacade Instance
        {
            get { return _instance.Value; }
        }

        #endregion [static]

        #region [systems]

        public IARMLoggerFacade Logger
        {
            get { return ARMLogger.Instance; }
        }

        public IARMMessageBoxFacade MessageBox
        {
            get { return _messageBoxFacade; }
        }

        public User CurrentUser { get; set; }

        #endregion [systems]
    }
}