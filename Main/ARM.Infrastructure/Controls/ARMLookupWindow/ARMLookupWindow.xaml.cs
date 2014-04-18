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
using ARM.Infrastructure.Controls.Interfaces;

namespace ARM.Infrastructure.Controls.ARMLookupWindow
{
    /// <summary>
    /// Interaction logic for ARMWindow.xaml
    /// </summary>
    public partial class ARMLookupWindow : Window
    {

        private IARMLookupViewModel _viewModel;

        public ARMLookupWindow(IARMLookupViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            Dispatcher.BeginInvoke((Action) (() => this.DataContext = _viewModel));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void ButtonBase_CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
