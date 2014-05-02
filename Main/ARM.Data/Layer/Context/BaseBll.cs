///////////////////////////////////////////////////////////
//  BaseBll.cs
//  Implementation of the Class BaseBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:38 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using ARM.Data.Layer.Interfaces;
using ARM.Data.Models;

namespace ARM.Data.Layer.Context
{
    public abstract class BaseBll<T> : IBll<T> where T : BaseModel
    {
        private IDal<T> _dal;

        public BaseBll(IDal<T> dal)
        {
            _dal = dal;
        }

        protected IDal<T> Dal
        {
            get { return _dal; }
        }

        ///
        /// <param name="obj"></param>
        public void Insert(T obj)
        {
            _dal.Insert(obj);
        }

        ///
        /// <param name="arg"></param>
        public void InsertAll(IEnumerable<T> arg)
        {
            _dal.InsertAll(arg);
        }

        ///
        /// <param name="obj"></param>
        public void Update(T obj)
        {
            _dal.Update(obj);
        }

        ///
        /// <param name="item"></param>
        public void Delete(T item)
        {
            _dal.Delete(item);
        }

        ///
        /// <param name="id"></param>
        public T GetById(Guid id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dal.GetAll();
        }

        public void Save()
        {
            _dal.Save();
        }

        public void Refresh()
        {
            _dal.Refresh();
        }

        public IEnumerable<T> GetAllWithRelated()
        {
            return _dal.GetAllWithRelated();
        }

        public void Dispose()
        {
            if(_dal != null)
                _dal.Dispose();
        }
    }//end BaseBll
}//end namespace Context