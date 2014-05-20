using System.Windows.Controls;
using ARM.Core.Interfaces;

namespace ARM.Infrastructure.MVVM.View
{
    /// <summary>
    /// Interaction logic for ARMToolboxView.xaml
    /// </summary>
    public partial class ARMToolboxView : UserControl, IARMToolboxView
    {
        public ARMToolboxView()
        {
            InitializeComponent();
        }
    }
}