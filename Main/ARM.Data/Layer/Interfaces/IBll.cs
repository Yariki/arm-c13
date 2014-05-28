﻿///////////////////////////////////////////////////////////
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
    /// <summary>
    /// Простір імен в якому акумульовані базові інтерфейси для доступу та роботи з даними БД.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }


    /// <summary>
    /// Інтерфейс бізнес-логіки для БД.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBll<T> : IDisposable
    {
        /// <summary>
        /// Додати елемент до БД.
        /// </summary>
        /// <param name="obj">Елемент.</param>
        void Insert(T obj);

        /// <summary>
        /// Додати список елементів до БД.
        /// </summary>
        /// <param name="list">Список.</param>
        void InsertAll(IEnumerable<T> list);

        /// <summary>
        /// Оновлення елементу в БД.
        /// </summary>
        /// <param name="obj">Елемент.</param>
        void Update(T obj);

        /// <summary>
        /// Видалення елементу з БД.
        /// </summary>
        /// <param name="obj">Елемент.</param>
        void Delete(T obj);

        /// <summary>
        /// Отримує елемент по його ідентифікатору.
        /// </summary>
        /// <param name="id">ідентифікатор.</param>
        /// <returns></returns>
        T GetById(Guid id);

        /// <summary>
        /// Повернути всі записи з БД.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Зберегти зміни в БД.
        /// </summary>
        void Save();

        /// <summary>
        /// Оновлення даних з БД.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Отримати всі дані з залежними записами.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAllWithRelated();

        /// <summary>
        /// Отримати всі замиси у відповідності до фільтру.
        /// </summary>
        /// <param name="filter">Фільтр.</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Func<T, bool> filter);

        /// <summary>
        /// Отримати всі записи у відповідності до виразу.
        /// </summary>
        /// <param name="filter">Вираз.</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
    } //end IBll
} //end namespace Interfaces