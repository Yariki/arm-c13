using ARM.Data.Models;

namespace ARM.Module.ViewModel.Services.CalculationStipend.Stipend
{
    /// <summary>
    /// Клас моделі представлення даних в сітці.
    /// </summary>
    public class ARMStudentStipendViewModel
    {
        public ARMStudentStipendViewModel()
        {
            
        }

        public Student Student { get; set; }

        public decimal Rate { get; set; }

        public decimal CurrentStipend { get; set; }

        public decimal CalculatedStipend { get; set; }

    }
}