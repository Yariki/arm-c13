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
using ARM.Module.Interfaces.Services.Mark.View;

namespace ARM.Module.View.Services.Mark
{
    /// <summary>
    /// Interaction logic for ARMMarkView.xaml
    /// </summary>
    public partial class ARMMarkView : UserControl,IARMMarkView
    {
        public ARMMarkView()
        {
            InitializeComponent();
        }
    }
}
