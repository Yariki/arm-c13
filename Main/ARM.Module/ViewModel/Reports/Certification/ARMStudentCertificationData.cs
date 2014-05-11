using System.Collections.Generic;
using ARM.Data.Models;

namespace ARM.Module.ViewModel.Reports.Certification
{
    public class ARMStudentCertificationData
    {
        private Dictionary<string,List<ARMCertificationDetailsData>> _dictvalues = new Dictionary<string, List<ARMCertificationDetailsData>>();
 
        public Student Student { get; set; }

        public object this[string key]
        {
            get { return _dictvalues.ContainsKey(key) ? _dictvalues[key] : null; }
            set
            {
                if (!_dictvalues.ContainsKey(key))
                {
                    _dictvalues[key] = new List<ARMCertificationDetailsData>();
                }
                _dictvalues[key].Add(value as ARMCertificationDetailsData);
            }
        }
    }
}