///////////////////////////////////////////////////////////
//  ISettingsBll.cs
//  Implementation of the Interface ISettingsBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:42 PM
///////////////////////////////////////////////////////////

using System;
using ARM.Data.Layer.Interfaces;
using ARM.Data.Models;

namespace ARM.Data.Interfaces.Settings
{
    public interface ISettingsBll : IBll<Models.SettingParameters>
    {
        Guid GetDefaultUniversity();

        Guid GetDefaultCountry();

        EducationLevel GetDefaultEducationLevel();

        InvoiceStatus GetDefaultInvoiceStatus();

        string GetContractPrefix();

        long GetNextContractNumber();

        string GetInvoicePrefix();

        long GetNextInvoiceNumber();

        string GetPaymentPrefix();

        long GetNextPaymentNumber();

        decimal GetCommomStipend();

        decimal GetIncreasedStipend();

        decimal GetCommonMark();

        decimal GetIncreasedMark();
    }//end ISettingsBll
}//end namespace Settings