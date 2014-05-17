using System.Windows.Controls;
using ARM.Module.Interfaces.Reports.View;

namespace ARM.Module.View.Reports
{
    /// <summary>
    /// Interaction logic for ARMDebtView.xaml
    /// </summary>
    public partial class ARMDebtView : UserControl, IARMDebtView
    {
        public ARMDebtView()
        {
            InitializeComponent();
        }
    }
}