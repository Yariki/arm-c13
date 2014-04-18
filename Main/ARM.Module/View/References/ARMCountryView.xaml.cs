using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Interaction logic for ARMCountryView.xaml
    /// </summary>
    public partial class ARMCountryView : UserControl, IARMCountryView
    {
        public ARMCountryView()
        {
            InitializeComponent();
        }
    }
}