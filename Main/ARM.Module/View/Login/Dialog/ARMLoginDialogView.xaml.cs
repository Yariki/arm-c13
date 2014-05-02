using System;
using System.Windows;
using ARM.Module.Interfaces.Login.View;
using ARM.Module.Interfaces.Login.ViewModel;

namespace ARM.Module.View.Login.Dialog
{
    /// <summary>
    /// Interaction logic for ARMLoginDialogView.xaml
    /// </summary>
    public partial class ARMLoginDialogView : Window, IARMLoginDialogView
    {
        private IARMLoginViewModel _viewModel;

        public ARMLoginDialogView(IARMLoginViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            _viewModel.CloseAction = CloseDlg;
            Dispatcher.BeginInvoke((Action)(() => this.DataContext = _viewModel));
        }

        private void CloseDlg(bool res)
        {
            DialogResult = res;
            Close();
        }
    }
}