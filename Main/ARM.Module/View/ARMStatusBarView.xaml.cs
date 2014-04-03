using System.Windows.Controls;
using ARM.Module.Interfaces.View;

namespace ARM.Module.View
{
    /// <summary>
    /// Interaction logic for ARMStatucBarView.xaml
    /// </summary>
    public partial class ARMStatusBarView : UserControl, IARMMainStatusBarView
    {
        public ARMStatusBarView()
        {
            InitializeComponent();
        }
    }
}