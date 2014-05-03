﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO.Pipes;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Permissions;
using ARM.Core.Attributes;

namespace ARM.Core.Extensions
{
    public static class ARMReflectionExtensions
    {
        #region [for types]

        public static IEnumerable<PropertyInfo> GetAllPublicProperties(this Type t)
        {
            Contract.Requires(t != null);
            return t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
        }

        public static bool HasProperty(this Type t, string name)
        {
            Contract.Requires(t != null);
            Contract.Requires(string.IsNullOrEmpty(name));
            return t.GetAllPublicProperties().Any(pi => pi.Name.ToLower() == name.ToLower());
        }

      public static bool HasAttribute<T>(this Type t)
      {
        Contract.Requires(t != null);
        return t.GetCustomAttributes(typeof (T), true).Any();
      }

      public static T GetAttribute<T>(this Type t )
      {
        Contract.Requires(t != null);
        return t.GetCustomAttributes(typeof (T), true).OfType<T>().ElementAt(0);
      }



        #endregion

        #region [property info]
        

        public static T GetPropertyValue<T>(this PropertyInfo pi, object context)
        {
            Contract.Requires(pi != null);
            Contract.Requires(context != null);

            return (T)pi.GetValue(context, null);
        }

        public static void SetPropertyValue<T>(this PropertyInfo pi, object context, T value)
        {
            Contract.Requires(pi  != null);
            Contract.Requires(context  != null);

            if (pi.IsNullable())
            {
                if (pi.PropertyType == typeof (Guid?))
                {
                    pi.SetValue(context, (value as Guid?).Value == Guid.Empty ? (object) null : (value as Guid?).Value, null);
                }
            }
            else
                pi.SetValue(context,value,null);
        }

        public static bool HasAttribute<T>(this PropertyInfo pi)
        {
            Contract.Requires(pi != null);
            
            var arr = pi.GetCustomAttributes(typeof(T), true);
            return arr.Length > 0;
        }

        public static T GetAttribute<T>(this PropertyInfo pi)
        {
            Contract.Requires(pi != null);
            var arr = pi.GetCustomAttributes(typeof (T), true);
            return (T)arr[0];
        }

        public static bool IsNullable(this PropertyInfo pi)
        {
            return Nullable.GetUnderlyingType(pi.PropertyType) != null;
        }

        #endregion

        #region [static]

        public static string GetPropertyName<T>(Expression<Func<T>> exp)
        {
            MemberExpression me = exp.Body as MemberExpression;
            if (me == null)
                return string.Empty;
            return me.Member.Name;
        }

        #endregion

    }
}