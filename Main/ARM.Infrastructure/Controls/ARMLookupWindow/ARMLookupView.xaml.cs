using System.Windows.Controls;
using ARM.Infrastructure.Controls.Interfaces.View;

namespace ARM.Infrastructure.Controls.ARMLookupWindow
{
    /// <summary>
    /// Interaction logic for ARMLookupView.xaml
    /// </summary>
    public partial class ARMLookupView : UserControl,IARMLookupView
    {
        public ARMLookupView()
        {
            InitializeComponent();
        }
    }
}
