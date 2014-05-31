namespace ARM.Data.Models
{
    /// <summary>
    /// Модель рейтингу
    /// </summary>
    public class Rate : BaseNamedModel
    {
        /// <summary>
        /// Ініціалізіція нового екземпляра  <see cref="Rate"/>.
        /// </summary>
        public Rate()
        {
            
        }
        /// <summary>
        /// Отримує або задає мінімальний рейтинг.
        /// </summary>
        public decimal RateMin { get; set; }

        /// <summary>
        /// Отримує або задає таксимальний рейтинг.
        /// </summary>
        public decimal RateMax { get; set; }

        /// <summary>
        /// Отримує або задає оцінка.
        /// </summary>
        public decimal Mark { get; set; }
    }
}