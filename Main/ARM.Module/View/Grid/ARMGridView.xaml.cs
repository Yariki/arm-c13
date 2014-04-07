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
using ARM.Infrastructure.Interfaces.Grid;

namespace ARM.Module.View.Grid
{
    /// <summary>
    /// Interaction logic for ARMGridView.xaml
    /// </summary>
    public partial class ARMGridView : UserControl,IARMGridView
    {
        public ARMGridView()
        {
            InitializeComponent();
        }
    }
}
