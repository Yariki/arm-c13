///////////////////////////////////////////////////////////
//  BaseDal.cs
//  Implementation of the Class BaseDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:38 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ARM.Data.Layer.Interfaces;
using ARM.Data.Models;

namespace ARM.Data.Layer.Context
{
    public abstract class BaseDal<T> : IDal<T> where T : BaseModel
    {
        protected IContext<T> Context;

        public BaseDal(IContext<T> context)
        {
            Context = context;
        }

        ///
        /// <param name="obj"></param>
        public void Insert(T obj)
        {
            Context.GetItems().Add(obj);
        }

        public void InsertAll(IEnumerable<T> list)
        {
            var items = Context.GetItems();
            foreach (var item in list)
            {
                items.Add(item);
            }
        }

        ///
        /// <param name="obj"></param>
        public void Update(T obj)
        {
            Context.Update(obj);
        }

        ///
        /// <param name="obj"></param>
        public void Delete(T obj)
        {
            if (obj == null)
                return;
            var entry = Context.GetItems().Find(obj.Id);
            DeleteAddInfo(entry);
            Context.GetItems().Remove(entry);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.GetItems().AsEnumerable();
        }

        ///
        /// <param name="id"></param>
        public T GetById(Guid id)
        {
            return Context.GetItems().FirstOrDefault(item => item.Id == id);
        }

        public void Save()
        {
            if (Context != null)
            {
                Context.Save();
            }
        }

        public void Refresh()
        {
            Context.Refresh();
        }

        public virtual IEnumerable<T> GetAllWithRelated()
        {
            return Context.GetItems().AsEnumerable();
        }

        public IEnumerable<T> GetAll(Func<T, bool> filter)
        {
            if (filter == null)
                return Context.GetItems().AsEnumerable();
            return Context.GetItems().Where(filter).AsEnumerable();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            if (filter == null)
                return Context.GetItems().AsEnumerable();
            return Context.GetItems().Where(filter).AsEnumerable();
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }

        protected virtual void DeleteAddInfo(T entity)
        {
        }
    }//end BaseDal
}//end namespace Context