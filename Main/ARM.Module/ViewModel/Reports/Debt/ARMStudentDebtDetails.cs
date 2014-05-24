using ARM.Data.Models;

namespace ARM.Module.ViewModel.Reports.Debt
{
    /// <summary>
    /// Клас для збереження даних по заборгованості студента.
    /// </summary>
    public class ARMStudentDebtDetails
    {
        public Student Student { get; set; }
        public Contract Contract { get; set; }
        public decimal Cost { get; set; }
        public decimal Debt { get; set; }
    }
}