///////////////////////////////////////////////////////////
//  ValidationEventArgs.cs
//  Implementation of the Class ValidationEventArgs
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 4:59:44 PM
///////////////////////////////////////////////////////////

using System;
using ARM.Core.Interfaces;

namespace ARM.Core.EventArguments
{
    public class ValidationEventArgs : EventArgs
    {
        public ValidationEventArgs()
        {
        }

        ~ValidationEventArgs()
        {
        }

        public IARMValidationResult Result
        {
            get;
            set;
        }
    }//end ValidationEventArgs
}//end namespace EventArguments