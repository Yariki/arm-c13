///////////////////////////////////////////////////////////
//  IContext.cs
//  Implementation of the Interface IContext
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:41 PM
///////////////////////////////////////////////////////////


using System.Data.Entity;

namespace ARM.Data.Layer.Interfaces {
	public interface IContext<T> where T : class
	{

		DbSet<T>  Items{
			get;
			set;
		}

		void Save();
	}//end IContext

}//end namespace Interfaces