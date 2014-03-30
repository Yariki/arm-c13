///////////////////////////////////////////////////////////
//  BaseDal.cs
//  Implementation of the Class BaseDal
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:38 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ARM.Data.Layer.Interfaces;
using ARM.Data.Models;

namespace ARM.Data.Layer.Context
{
    public class BaseDal<T> : IDal<T> where T : class
    {
        private IContext<T> _context;

        public BaseDal(IContext<T> context)
        {
            _context = context;
        }

        ///
        /// <param name="obj"></param>
        public void Insert(T obj)
        {
            _context.GetItems().Add(obj);
        }

        public void InsertAll(IEnumerable<T> list)
        {
            var items = _context.GetItems();
            foreach (var item in list)
            {
                items.Add(item);
            }
        }

        ///
        /// <param name="obj"></param>
        public void Update(T obj)
        {
            
        }

        ///
        /// <param name="obj"></param>
        public void Delete(T obj)
        {
            _context.GetItems().Remove(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.GetItems();
        }

        ///
        /// <param name="id"></param>
        public T GetById(Guid id)
        {
            return _context.GetItems().FirstOrDefault(item => (item as BaseModel).Id == id);
        }
    }//end BaseDal
}//end namespace Context