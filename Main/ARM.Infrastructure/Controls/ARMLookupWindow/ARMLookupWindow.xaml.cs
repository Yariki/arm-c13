using System;
using System.Windows;
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
            _viewModel.Cancel += ViewModelOnCancel;
            Dispatcher.BeginInvoke((Action)(() => this.DataContext = _viewModel));
        }

        private void ViewModelOnCancel(object sender, EventArgs eventArgs)
        {
            _viewModel.Cancel -= ViewModelOnCancel;
            DialogResult = false;
            Close();
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