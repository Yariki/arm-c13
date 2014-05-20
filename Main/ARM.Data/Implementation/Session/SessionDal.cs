﻿///////////////////////////////////////////////////////////
//  SessionDal.cs
//  Implementation of the Class SessionDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:45 PM
///////////////////////////////////////////////////////////

using ARM.Data.Interfaces.Session;
using ARM.Data.Layer.Context;
using ARM.Data.Layer.Interfaces;

namespace ARM.Data.Implementation.Session
{
    /// <summary>
    /// Реалізація доступу до даних для сесій
    /// </summary>
    public class SessionDal : BaseDal<Models.Session>, ISessionDal
    {
        public SessionDal(IContext<Models.Session> context)
            : base(context)
        {
        }
    } //end SessionDal
} //end namespace Session