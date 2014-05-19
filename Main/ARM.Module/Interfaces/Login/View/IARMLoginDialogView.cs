namespace ARM.Module.Interfaces.Login.View
{
    /// <summary>
    /// Інтерфейс діалогу представлення для логіна
    /// </summary>
    public interface IARMLoginDialogView
    {
        /// <summary>
        /// Відобразити вікно логіна.
        /// </summary>
        /// <returns></returns>
        bool? ShowDialog();
    }
}