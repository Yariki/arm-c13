///////////////////////////////////////////////////////////
//  IBll.cs
//  Implementation of the Interface IBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:40 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ARM.Data.Layer.Interfaces
{
    public interface IBll<T> : IDisposable
    {
        /// <param name="obj"></param>
        void Insert(T obj);

        /// <param name="list"></param>
        void InsertAll(IEnumerable<T> list);

        /// <param name="obj"></param>
        void Update(T obj);

        /// <param name="id"></param>
        void Delete(T obj);

        /// <param name="id"></param>
        T GetById(Guid id);

        IEnumerable<T> GetAll();

        void Save();

        void Refresh();

        IEnumerable<T> GetAllWithRelated();

        IEnumerable<T> GetAll(Func<T, bool> filter);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
    } //end IBll
} //end namespace Interfaces