using System;
using System.Collections.Generic;
using ARM.Resource.AppResource;

namespace ARM.Infrastructure.Helpers
{
    /// <summary>
    /// Класс, призначени для локалізкації значеннь типів-перечислень.
    /// </summary>
    public class ARMEnumHelper
    {
        private const string EnumPrefix = "Enum_";

        #region [ctor]

        /// <summary>
        /// Запобігає примірник за замовчуванням на <see класу cref="ARMEnumHelper"/> від створюються.
        /// </summary>
        private ARMEnumHelper()
        {
        }

        #endregion [ctor]

        #region [instance]

        private static Lazy<ARMEnumHelper> _instance = new Lazy<ARMEnumHelper>(() => new ARMEnumHelper());

        /// <summary>
        /// Отримує екземпляр.
        /// </summary>
        public static ARMEnumHelper Instance
        {
            get { return _instance.Value; }
        }

        #endregion [instance]

        /// <summary>
        /// Отримує локалізовані дані для типу.
        /// </summary>
        /// <typeparam name="T">Тип-перечислення, для якого проводиться пошук локалі.</typeparam>
        /// <returns></returns>
        public Dictionary<T, string> GetLocalsForEnum<T>() where T : struct, IComparable, IConvertible, IFormattable
        {
            if (!typeof(T).IsEnum)
                return null;
            Dictionary<T, string> dic = new Dictionary<T, string>();
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                var localName = Resources.ResourceManager.GetString(EnumPrefix + value.ToString()) ?? value.ToString();
                dic.Add((T)value, localName);
            }
            return dic;
        }
    }
}