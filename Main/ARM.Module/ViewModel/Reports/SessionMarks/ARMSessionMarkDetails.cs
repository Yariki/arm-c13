namespace ARM.Module.ViewModel.Reports.SessionMarks
{
    /// <summary>
    /// Класс для збереження інформації для оцінкам за сесію.
    /// </summary>
    public class ARMSessionMarkDetails
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal Mark { get; set; }
    }
}