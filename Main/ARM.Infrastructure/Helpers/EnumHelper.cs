using System;
using System.Collections.Generic;
using ARM.Resource.AppResource;

namespace ARM.Infrastructure.Helpers
{
    public class EnumHelper
    {
        private const string EnumPrefix = "Enum_";

        #region [ctor]

        private EnumHelper()
        {
            
        }

        #endregion

        #region [instance]

        private static Lazy<EnumHelper> _instance = new Lazy<EnumHelper>(() => new EnumHelper());

        public static  EnumHelper Instance
        {
            get { return _instance.Value; }
        }

        #endregion

        public Dictionary<T, string> GetLocalsForEnum<T>() where T : struct, IComparable, IConvertible, IFormattable
        {
            if(!typeof(T).IsEnum)
                return null;
            Dictionary<T,string> dic = new Dictionary<T, string>();
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                var localName =  Resources.ResourceManager.GetString(EnumPrefix + value.ToString());
                dic.Add((T)value,localName);
            }
            return dic;
        }

    }
}