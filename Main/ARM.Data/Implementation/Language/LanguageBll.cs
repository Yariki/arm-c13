///////////////////////////////////////////////////////////
//  LanguageBll.cs
//  Implementation of the Class LanguageBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:43 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Language;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Language
{
    public class LanguageBll : BaseBll<Models.Language>, ILanguageBll
    {
        public LanguageBll(IDal<Models.Language> dal)
            : base(dal)
        {
        }
    }//end LanguageBll
}//end namespace Language