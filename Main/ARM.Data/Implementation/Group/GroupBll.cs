﻿///////////////////////////////////////////////////////////
//  GroupBll.cs
//  Implementation of the Class GroupBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:40 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Group;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;


namespace ARM.Data.Implementation.Group
{
/// <summary>
/// Простір імен для реалізації функциональності по роботі з - групами
/// </summary>

    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }
    /// <summary>
    /// Реалізація бізнес логіки для груп
    /// </summary>
    public class GroupBll : BaseBll<Models.Group>, IGroupBll
    {
        /// <summary>
        /// Створити екземпляр <see cref="GroupBll"/> class.
        /// </summary>
        /// <param name="dal">The dal.</param>
        public GroupBll(IDal<Models.Group> dal)
            : base(dal)
        {
        }
    } //end GroupBll
} //end namespace Group