///////////////////////////////////////////////////////////
//  SettingsBll.cs
//  Implementation of the Class SettingsBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:45 PM
///////////////////////////////////////////////////////////

using System;
using ARM.Core.Const;
using ARM.Data.Interfaces.Settings;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;
using ARM.Data.Models;

namespace ARM.Data.Implementation.Settings
{
    public class SettingsBll : BaseBll<Models.SettingParameters>, ISettingsBll
    {
        public SettingsBll(IDal<SettingParameters> dal)
            : base(dal)
        {
        }

        public Guid GetDefaultUniversity()
        {
            var entity = GetDefaultParameters();
            return entity != null ? entity.DefUniversity : Guid.Empty;
        }

        public Guid GetDefaultCountry()
        {
            var entity = GetDefaultParameters();
            return entity != null ? entity.DefCountry : Guid.Empty;
        }

        public EducationLevel GetDefaultEducationLevel()
        {
            var entity = GetDefaultParameters();
            return entity != null ? entity.DefEducationLevel : EducationLevel.Bachelour;
        }

        public InvoiceStatus GetDefaultInvoiceStatus()
        {
            var entity = GetDefaultParameters();
            return entity != null ? entity.DefInvoiceStatus : InvoiceStatus.None;
        }

        private SettingParameters GetDefaultParameters()
        {
            return GetById(GlobalConst.IdDefault);
        }

    }//end SettingsBll
}//end namespace Settings