///////////////////////////////////////////////////////////
//  SettingsDal.cs
//  Implementation of the Class SettingsDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:45 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Settings;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;
using ARM.Data.Models;

namespace ARM.Data.Implementation.Settings
{
    public class SettingsDal : BaseDal<Models.SettingParameters>, ISettingsDal
    {
        public SettingsDal(IContext<SettingParameters> context)
            : base(context)
        {
        }
    }//end SettingsDal
}//end namespace Settings