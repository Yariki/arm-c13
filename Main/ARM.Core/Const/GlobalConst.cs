using System;

/// <summary>
/// Простір імен, який включає глобальні константи, що використовуються.
/// </summary>
namespace ARM.Core.Const
{
    /// <summary>
    /// Глобальний класс констант
    /// </summary>
    public static class GlobalConst
    {
        /// <summary>
        /// Ідентифікатор для значень по замовчуванню (базові значення в БД)
        /// </summary>
        private const string GuidDefaultStr = "00000000-0000-0000-0000-000000000001";

        /// <summary>
        /// конвертує ідентифікатор в класс Guid
        /// </summary>
        public static readonly Guid IdDefault = Guid.Parse(GuidDefaultStr);
    }
}