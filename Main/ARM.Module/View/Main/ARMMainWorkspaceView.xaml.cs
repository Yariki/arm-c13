using System.Windows.Controls;
using ARM.Module.Interfaces.View;

namespace ARM.Module.View.Main
{
    /// <summary>
    ///     Interaction logic for ARMMainWorkspaceView.xaml
    /// </summary>
    public partial class ARMMainWorkspaceView : UserControl, IARMMainWorkspaceView
    {
        public ARMMainWorkspaceView()
        {
            InitializeComponent();
        }
    }
}