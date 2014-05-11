using System.ComponentModel;
using System.Windows.Input;

namespace ARM.Core.Interfaces
{
    public interface IARMReportViewModel : IARMWorkspaceViewModel, IDataErrorInfo
    {
        ICommand ExportCommand { get; }
    }
}