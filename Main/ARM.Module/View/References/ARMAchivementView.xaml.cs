using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ARM.Infrastructure.Controls.Interfaces.View;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Interaction logic for ARMAchivementView.xaml
    /// </summary>
    public partial class ARMAchivementView : UserControl,IARMAchivementView,IARMDialogView
    {
        public ARMAchivementView()
        {
            InitializeComponent();
        }
    }
}
