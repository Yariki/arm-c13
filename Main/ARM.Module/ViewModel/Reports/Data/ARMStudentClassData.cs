using System.Collections.Generic;
using ARM.Data.Models;

namespace ARM.Module.ViewModel.Reports.Data
{
    public class ARMStudentClassData<T> where T : class
    {
        private Dictionary<string, List<T>> _dictvalues = new Dictionary<string, List<T>>();

        public Student Student { get; set; }

        public object this[string key]
        {
            get { return _dictvalues.ContainsKey(key) ? _dictvalues[key] : null; }
            set
            {
                if (!_dictvalues.ContainsKey(key))
                {
                    _dictvalues[key] = new List<T>();
                }
                _dictvalues[key].Add(value as T);
            }
        }
    }
}