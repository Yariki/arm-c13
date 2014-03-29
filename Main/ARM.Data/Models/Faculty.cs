///////////////////////////////////////////////////////////
//  Faculty.cs
//  Implementation of the Class Faculty
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:39 PM
///////////////////////////////////////////////////////////




using ARM.Data.Models;
namespace ARM.Data.Models {
	public class Faculty : BaseNamedModel {

		public Faculty(){

		}

		~Faculty(){

		}

		public long StaffId{
			get;
			set;
		}

		public virtual Staff Head{
			get;
			set;
		}

		public long UnivarsityId{
			get;
			set;
		}

		public virtual University Univarsity{
			get;
			set;
		}

	}//end Faculty

}//end namespace Models