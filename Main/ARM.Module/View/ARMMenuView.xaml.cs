using System.Windows.Controls;
using ARM.Module.Interfaces.View;

namespace ARM.Module.View
{
    /// <summary>
    ///     Interaction logic for ARMMenuView.xaml
    /// </summary>
    public partial class ARMMenuView : UserControl, IARMMainMenuView
    {
        public ARMMenuView()
        {
            InitializeComponent();
        }
    }
}