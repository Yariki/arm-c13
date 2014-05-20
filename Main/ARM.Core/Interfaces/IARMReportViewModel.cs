using System.ComponentModel;
using System.Windows.Input;

namespace ARM.Core.Interfaces
{
    /// <summary>
    /// інтерфейс призначений для звітів
    /// </summary>
    public interface IARMReportViewModel : IARMWorkspaceViewModel, IDataErrorInfo
    {
        /// <summary>
        /// Команда для експорту даних звіту
        /// </summary>
        ICommand ExportCommand { get; }
    }
}