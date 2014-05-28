using ARM.Data.Models;

namespace ARM.Module.ViewModel.Reports.Deduct
{
    /// <summary>
    /// Класс для зберігання розразхованої ынформацыъ щодо успішності студента протягом семестра.
    /// Використовується при поданні списків на відрахування.
    /// </summary>
    public class ARMStudentDeduct
    {
        /// <summary>
        /// Отримує або задає студента.
        /// </summary>
        public Student Student { get; set; }
        /// <summary>
        /// Отримує або задає примітку.
        /// </summary>
        public string Note { get; set; }
    }
}