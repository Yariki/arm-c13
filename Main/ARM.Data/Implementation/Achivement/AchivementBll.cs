﻿///////////////////////////////////////////////////////////
//  AchivementBll.cs
//  Implementation of the Class AchivementBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:37 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Achivement;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

/// <summary>
/// Простір імен для реалізації функциональності по роботі з - досягненнями
/// </summary>
namespace ARM.Data.Implementation.Achivement
{
    /// <summary>
    /// Реалізація бізнес логіки для досягнень
    /// </summary>
    public class AchivementBll : BaseBll<Models.Achivement>, IAchivementBll
    {

        /// <summary>
        /// Створити екземпляр <see cref="AchivementBll"/> class.
        /// </summary>
        /// <param name="dal">The dal.</param>
        public AchivementBll(IDal<Models.Achivement> dal)
            : base(dal)
        {
        }
    } //end AchivementBll
} //end namespace Achivement