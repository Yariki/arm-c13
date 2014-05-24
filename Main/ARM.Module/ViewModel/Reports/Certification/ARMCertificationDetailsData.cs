using System;

namespace ARM.Module.ViewModel.Reports.Certification
{
    /// <summary>
    /// Клас для збереження даних по атестаціям.
    /// </summary>
    public class ARMCertificationDetailsData
    {
        public string Name { get; set; }
        public bool IsCertificated { get; set; }
        public DateTime Date { get; set; }
    }
}