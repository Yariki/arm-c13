using System;
using System.Collections;

namespace ManagedExcel
{	
	/// <summary>
	/// Wrapper for Excel.Application
    /// http://www.codeproject.com/KB/COM/safecomwrapper.aspx
	/// </summary>
	public class ExcelApplication
	{
		public static Application Create()
		{
			return (Application)COMWrapper.CreateInstance(typeof(Application));
		}
	}
}
