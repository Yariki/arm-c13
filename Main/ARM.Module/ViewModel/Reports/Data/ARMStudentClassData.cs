using System.Collections.Generic;
using System.Linq;
using ARM.Data.Models;

namespace ARM.Module.ViewModel.Reports.Data
{
    /// <summary>
    /// Базовий класс для збереження інформації, що стосується певного студента.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ARMStudentClassData<T> where T : class
    {
        private Dictionary<string, List<T>> _dictvalues = new Dictionary<string, List<T>>();

        /// <summary>
        /// Отримує або задає студента.
        /// </summary>
        public Student Student { get; set; }

        /// <summary>
        /// Отримує   або задає значення за певним ключом.
        /// </summary>
        /// <param name="key">Ключ.</param>
        public object this[string key]
        {
            get { return _dictvalues.ContainsKey(key) ? (object) _dictvalues[key] : string.Empty; }
            set
            {
                if (!_dictvalues.ContainsKey(key))
                {
                    _dictvalues[key] = new List<T>();
                }
                _dictvalues[key].Add(value as T);
            }
        }

        /// <summary>
        /// Кількість даних.
        /// </summary>
        public int Count
        {
            get { return _dictvalues.Count; } 
        }

        /// <summary>
        /// Отримати пару ключ-значення за їх індексом.
        /// </summary>
        /// <param name="index">Індекс.</param>
        /// <returns></returns>
        public KeyValuePair<string, List<T>> GetKeyValue(int index)
        {
            if (index >= _dictvalues.Count)
                return default(KeyValuePair<string, List<T>>);
            return _dictvalues.ElementAt(index);
        }
 

    }
}