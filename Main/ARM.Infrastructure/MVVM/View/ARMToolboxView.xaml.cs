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
using ARM.Core.Interfaces;

namespace ARM.Infrastructure.MVVM.View
{
    /// <summary>
    /// Interaction logic for ARMToolboxView.xaml
    /// </summary>
    public partial class ARMToolboxView : UserControl,IARMToolboxView
    {
        public ARMToolboxView()
        {
            InitializeComponent();
        }
    }
}
