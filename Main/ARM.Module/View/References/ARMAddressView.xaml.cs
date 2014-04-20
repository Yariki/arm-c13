using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Interaction logic for ARMAddressView.xaml
    /// </summary>
    public partial class ARMAddressView : UserControl, IARMAddressView
    {
        public ARMAddressView()
        {
            InitializeComponent();
        }
    }
}