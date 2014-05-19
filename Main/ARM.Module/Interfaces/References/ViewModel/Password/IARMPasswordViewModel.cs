using System.ComponentModel;
using System.Runtime.CompilerServices;
using ARM.Core.Interfaces;

namespace ARM.Module.Interfaces.References.ViewModel.Password
{
    /// <summary>
    /// Інтерфейс моделі представлення для пароля.
    /// </summary>
    public interface IARMPasswordViewModel : IARMDataViewModel,IDataErrorInfo
    {
        /// <summary>
        /// Отримує або задає перший варіант пароля.
        /// </summary>
        string Password1 { get; set; }
        /// <summary>
        /// Отримує аббо задає повтор пароля.
        /// </summary>
        string Password2 { get; set; }
    }
    
}