﻿///////////////////////////////////////////////////////////
//  BaseBll.cs
//  Implementation of the Class BaseBll
//  Generated by Enterprise Architect
//  Created on:      29-Mar-2014 5:16:38 PM
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ARM.Data.Layer.Interfaces;
using ARM.Data.Models;

namespace ARM.Data.Layer.Context
{
    /// <summary>
    /// Базова реалізація бізнес-логіки для БД.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseBll<T> : IBll<T> where T : BaseModel
    {
        private IDal<T> _dal;

        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="BaseBll{T}"/>.
        /// </summary>
        /// <param name="dal">Клас доступу до даних.</param>
        public BaseBll(IDal<T> dal)
        {
            _dal = dal;
        }

        /// <summary>
        /// Отримати обєкт класу доступу до даних.
        /// </summary>
        protected IDal<T> Dal
        {
            get { return _dal; }
        }

        /// <summary>
        /// Додати елемент до БД.
        /// </summary>
        /// <param name="obj">Елемент.</param>
        public void Insert(T obj)
        {
            _dal.Insert(obj);
        }

        /// <summary>
        /// Додати список елементів до БД.
        /// </summary>
        /// <param name="arg">Список.</param>
        public void InsertAll(IEnumerable<T> arg)
        {
            _dal.InsertAll(arg);
        }

        /// <summary>
        /// Оновити елемент в БД.
        /// </summary>
        /// <param name="obj">Елемент.</param>
        public void Update(T obj)
        {
            _dal.Update(obj);
        }

        /// <summary>
        /// Видалити елемент з БД.
        /// </summary>
        /// <param name="item">Елемент.</param>
        public void Delete(T item)
        {
            _dal.Delete(item);
        }

        /// <summary>
        /// Отримати елемент по його ідентифікатору.
        /// </summary>
        /// <param name="id">Ідентифікатор.</param>
        /// <returns></returns>
        public T GetById(Guid id)
        {
            return _dal.GetById(id);
        }

        /// <summary>
        /// Повернути всі записи.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _dal.GetAll();
        }

        /// <summary>
        /// Зберегти всі зміни в БД.
        /// </summary>
        public void Save()
        {
            _dal.Save();
        }

        /// <summary>
        /// Оновити записи з БД.
        /// </summary>
        public void Refresh()
        {
            _dal.Refresh();
        }

        /// <summary>
        /// Повернути всі записи з залежними елементами.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAllWithRelated()
        {
            return _dal.GetAllWithRelated();
        }

        /// <summary>
        /// Взяти всі елементи відповідно до фільтру.
        /// </summary>
        /// <param name="filter">Фільтр.</param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Func<T, bool> filter)
        {
            return _dal.GetAll(filter);
        }

        /// <summary>
        /// Повертнути всі елементи відповідно до виразу.
        /// </summary>
        /// <param name="filter">Вираз.</param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _dal.GetAll(filter);
        }

        /// <summary>
        /// Виконує визначаються додатком завдання, пов'язані з вивільненням або скиданням некерованих ресурсів.
        /// </summary>
        public void Dispose()
        {
            if (_dal != null)
                _dal.Dispose();
        }
    }//end BaseBll
}//end namespace Context