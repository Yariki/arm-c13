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

namespace ARM.Module.View.Help
{
    /// <summary>
    /// Interaction logic for ARMAbout.xaml
    /// </summary>
    public partial class ARMAbout : Window
    {
        public ARMAbout()
        {
            InitializeComponent();
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
