using System;
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
	/// <summary>
	/// класс-контейнер для методів розширення повязаних з рефлексією.
	/// </summary>
	public static class ARMReflectionExtensions
	{
		#region [for types]

		/// <summary>
		/// повертає всі відкриті властивості  типу
		/// </summary>
		/// <param name="t">тип</param>
		/// <returns></returns>
		public static IEnumerable<PropertyInfo> GetAllPublicProperties(this Type t)
		{
			Contract.Requires(t != null);
			return t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
		}

		/// <summary>
		/// перевіряє, чи присмсутня властивість в даному типі по назві
		/// </summary>
		/// <param name="t">тип</param>
		/// <param name="name">назва властивості</param>
		/// <returns></returns>
		public static bool HasProperty(this Type t, string name)
		{
			Contract.Requires(t != null);
			Contract.Requires(string.IsNullOrEmpty(name));
			return t.GetAllPublicProperties().Any(pi => pi.Name.ToLower() == name.ToLower());
		}

		/// <summary>
		/// перевіряє, чи присутній вказаний атрибут в даному типі
		/// </summary>
		/// <param name="t">тип</param>
		/// <returns></returns>
		public static bool HasAttribute<T>(this Type t)
		{
			Contract.Requires(t != null);
			return t.GetCustomAttributes(typeof (T), true).Any();
		}

		/// <summary>
		/// повертає вказаний атрибут по типу
		/// </summary>
		/// <param name="t">тип</param>
		/// <returns></returns>
		public static T GetAttribute<T>(this Type t )
		{
			Contract.Requires(t != null);
			return t.GetCustomAttributes(typeof (T), true).OfType<T>().ElementAt(0);
		}



		#endregion

		#region [property info]
		

		/// <summary>
		/// повертає значення властивості
		/// </summary>
		/// <param name="pi">об'єкт типа PropertyInfo</param>
		/// <param name="context">об'єкт обробки </param>
		/// <returns></returns>
		public static T GetPropertyValue<T>(this PropertyInfo pi, object context)
		{
			Contract.Requires(pi != null);
			Contract.Requires(context != null);

			return (T)pi.GetValue(context, null);
		}

		/// <summary>
		/// встановлює значення властивості для об'єкта
		/// </summary>
		/// <param name="pi">об'єкт типу PropertyInfo</param>
		/// <param name="context">об'єкт обробки</param>
		/// <param name="value">значення, що встановлюється</param>
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
		/// <summary>
		/// перевіряє, чи присутній атрибут у вказаній властивості
		/// </summary>
		/// <param name="pi">об'єкт типу PropertyInfo</param>
		public static bool HasAttribute<T>(this PropertyInfo pi)
		{
			Contract.Requires(pi != null);
			
			var arr = pi.GetCustomAttributes(typeof(T), true);
			return arr.Length > 0;
		}

		/// <summary>
		/// повертає об'єкт атрибуту для вказаної властивості
		/// </summary>
		/// <param name="pi">об'єкт типу PropertyInfo</param>
		public static T GetAttribute<T>(this PropertyInfo pi)
		{
			Contract.Requires(pi != null);
			var arr = pi.GetCustomAttributes(typeof (T), true);
			return (T)arr[0];
		}
		
		/// <summary>
		/// перевіряє, чи властивість може приймати значення 'null'
		/// </summary>
		/// <param name="pi">об'єкт типу PropertyInfo</param>
		public static bool IsNullable(this PropertyInfo pi)
		{
			return Nullable.GetUnderlyingType(pi.PropertyType) != null;
		}

		#endregion

		#region [static]
		/// <summary>
		/// повертає назву властивості з передано виразу
		/// </summary>
		/// <param name="exp">вираз</param>
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