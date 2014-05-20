namespace ARM.Core.Attributes
{
    /// <summary>
    /// атрибут, котрий визначає позиціє поля в сітці.
    /// </summary>
    public class ARMGridAttribute : ARMBaseAttribute
    {
        /// <summary>
        /// індекс колонки в сітці, по-замовчуванню
        /// </summary>
        public int Order { get; set; }
    }
}