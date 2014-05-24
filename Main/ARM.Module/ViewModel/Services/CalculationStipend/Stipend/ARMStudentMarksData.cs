using System;
using System.Collections.Generic;
using ARM.Data.Models;

namespace ARM.Module.ViewModel.Services.CalculationStipend.Stipend
{
    /// <summary>
    /// Клас для збереження даних по резільтатам сесії для студента.
    /// </summary>
    public class ARMStudentMarksData
    {
        public ARMStudentMarksData()
        {
            SumMarks = new Dictionary<Guid, Rate>();
        }

        public Guid StudentId { get; set; }

        public Dictionary<Guid,Rate> SumMarks { get; private set; }

    }
}