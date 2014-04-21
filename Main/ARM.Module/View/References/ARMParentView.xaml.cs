using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Interaction logic for ARMParentView.xaml
    /// </summary>
    public partial class ARMParentView : UserControl, IARMParentView
    {
        public ARMParentView()
        {
            InitializeComponent();
        }
    }
}