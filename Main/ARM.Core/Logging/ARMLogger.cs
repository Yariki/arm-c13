using System.IO;
using System.Reflection;
using ARM.Core.Interfaces;
using ARM.Infrastructure.Enums;
using log4net;
using log4net.Config;
using Microsoft.Practices.Prism.Logging;

namespace ARM.Core.Logging
{
    public class ARMLogger : IARMLoggerFacade, ILoggerFacade
    {
        private const string Filename = "log4net.config";

        #region fields

        private ILog _log;

        #endregion fields

        #region fields static

        private static ARMLogger _instance = null;
        private static object _lock = new object();

        #endregion fields static

        #region [ctor]

        private ARMLogger()
        {
            string path = Assembly.GetAssembly(typeof(ARMLogger)).Location;
            path = path.Substring(0, path.LastIndexOf('\\') + 1);
            path = path + Filename;
            System.Diagnostics.Debug.WriteLine(path);
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                var col = XmlConfigurator.Configure(fi);
                _log = log4net.LogManager.GetLogger("ARMLogger");
            }
        }

        #endregion [ctor]

        public static IARMLoggerFacade Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ARMLogger();
                    }
                    return _instance;
                }
            }
        }

        #region [logging]

        public void LogError(string message)
        {
            WriteLog(eARMLogLevel.Error, message);
        }

        public void LogError(string format, object[] args)
        {
            string message = string.Format(format, args);
            WriteLog(eARMLogLevel.Error, message);
        }

        public void LogWarning(string message)
        {
            WriteLog(eARMLogLevel.Warning, message);
        }

        public void LogWarning(string format, object[] args)
        {
            string message = string.Format(format, args);
            WriteLog(eARMLogLevel.Warning, message);
        }

        public void LogInfo(string message)
        {
            WriteLog(eARMLogLevel.Info, message);
        }

        public void LogInfo(string format, object[] args)
        {
            string message = string.Format(format, args);
            WriteLog(eARMLogLevel.Info, message);
        }

        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Warn:
                    WriteLog(eARMLogLevel.Warning, message);
                    break;

                case Category.Debug:
                    WriteLog(eARMLogLevel.Info, message);
                    break;

                case Category.Info:
                    WriteLog(eARMLogLevel.Info, message);
                    break;

                case Category.Exception:
                    WriteLog(eARMLogLevel.Error, message);
                    break;
            }
        }

        #endregion [logging]

        #region private

        private void WriteLog(eARMLogLevel level, string message)
        {
            if (_log == null)
                return;
            switch (level)
            {
                case eARMLogLevel.Info:
                    _log.Info(message);
                    break;

                case eARMLogLevel.Warning:
                    _log.Warn(message);
                    break;

                case eARMLogLevel.Error:
                    _log.Error(message);
                    break;

                default:
                    break;
            }
        }

        #endregion private
    }
}