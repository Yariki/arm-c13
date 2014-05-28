using System.IO;
using System.Reflection;
using ARM.Core.Interfaces;
using ARM.Infrastructure.Enums;
using log4net;
using log4net.Config;
using Microsoft.Practices.Prism.Logging;

namespace ARM.Core.Logging
{
    /// <summary>
    /// Простір імен, що містить класс, який забеспечує роботу системи логування.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }

    /// <summary>
    /// класс відповідай за функціональність логування.
    /// </summary>
    public class ARMLogger : IARMLoggerFacade, ILoggerFacade
    {
        /// <summary>
        /// файл налаштування
        /// </summary>
        private const string Filename = "log4net.config";

        #region fields

        /// <summary>
        /// внутрішній обєкт логування.
        /// </summary>
        private ILog _log;

        #endregion fields

        #region fields static

        /// <summary>
        /// статичний обєкт классу ARMLogger. Призначений для реалізації патерну Singleton
        /// </summary>
        private static ARMLogger _instance = null;

        private static object _lock = new object();

        #endregion fields static

        #region [ctor]

        /// <summary>
        /// Контруктор, що запобігай створенню обєкта.
        /// </summary>
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

        /// <summary>
        /// Повертає обєкь логування
        /// </summary>
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

        /// <summary>
        /// Метод для логування помилок
        /// </summary>
        /// <param name="message">Повідомлення</param>
        public void LogError(string message)
        {
            WriteLog(eARMLogLevel.Error, message);
        }

        /// <summary>
        /// Метод для логування помилок
        /// </summary>
        /// <param name="format">Формат.</param>
        /// <param name="args">Аргументи повідомлення.</param>
        public void LogError(string format, object[] args)
        {
            string message = string.Format(format, args);
            WriteLog(eARMLogLevel.Error, message);
        }

        /// <summary>
        /// Метод для логування попереджень
        /// </summary>
        /// <param name="message">Повідомлення.</param>
        public void LogWarning(string message)
        {
            WriteLog(eARMLogLevel.Warning, message);
        }

        /// <summary>
        /// Метод для логування попереджень
        /// </summary>
        /// <param name="format">Формат.</param>
        /// <param name="args">Аргументи повідомлення.</param>
        public void LogWarning(string format, object[] args)
        {
            string message = string.Format(format, args);
            WriteLog(eARMLogLevel.Warning, message);
        }

        /// <summary>
        /// Метод для логування корисної інформації
        /// </summary>
        /// <param name="message">Повідомлення.</param>
        public void LogInfo(string message)
        {
            WriteLog(eARMLogLevel.Info, message);
        }

        /// <summary>
        /// Метод для логування корисної інформації
        /// </summary>
        /// <param name="format">Формат.</param>
        /// <param name="args">Аргументи повідомлення.</param>
        public void LogInfo(string format, object[] args)
        {
            string message = string.Format(format, args);
            WriteLog(eARMLogLevel.Info, message);
        }

        /// <summary>
        /// Написати новий запис журналу з зазначеної категорії та пріоритету.
        /// </summary>
        /// <param name="message">Тіфло повідомлення.</param>
        /// <param name="category">Категоря повідомлення.</param>
        /// <param name="priority">Пріоритет повібдомлення.</param>
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

        /// <summary>
        /// Запис в  журнал.
        /// </summary>
        /// <param name="level">Рівень.</param>
        /// <param name="message">Повідомлення.</param>
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