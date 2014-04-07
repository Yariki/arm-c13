using ARM.Module.Interfaces;

namespace ARM.Client
{
    public interface IMainWindow
    {
        IARMMainWorkspaceViewModel Model { get; set; }
    }
}