using System;
using System.Windows;
using ARM.Infrastructure.Controls.Interfaces;

namespace ARM.Infrastructure.Controls.ARMDialogWindow
{
    /// <summary>
    /// Interaction logic for ARMWindow.xaml
    /// </summary>
    public partial class ARMDialogWindow : Window
    {
        private IARMDialogViewModel _viewModel;

        public ARMDialogWindow(IARMDialogViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            Dispatcher.BeginInvoke((Action)(() => this.DataContext = _viewModel));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_viewModel.Validate())
                return;
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