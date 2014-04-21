using System.Windows.Controls;
using ARM.Infrastructure.Interfaces.Grid;

namespace ARM.Module.View.Grid
{
    /// <summary>
    ///     Interaction logic for ARMGridView.xaml
    /// </summary>
    public partial class ARMGridView : UserControl, IARMGridView
    {
        public ARMGridView()
        {
            InitializeComponent();
        }
    }
}