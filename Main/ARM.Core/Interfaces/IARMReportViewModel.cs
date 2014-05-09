using System.Windows.Input;

namespace ARM.Core.Interfaces
{
    public interface IARMReportViewModel : IARMWorkspaceViewModel
    {
        ICommand ExportCommand { get; }
    }
}