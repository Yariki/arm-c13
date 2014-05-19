using System;
using System.Windows;
using ARM.Module.Interfaces.Login.View;
using ARM.Module.Interfaces.Login.ViewModel;

namespace ARM.Module.View.Login.Dialog
{
    /// <summary>
    /// Преставлення дла роботи з вікном логіна при старті програми.
    /// </summary>
    public partial class ARMLoginDialogView : Window, IARMLoginDialogView
    {
        private IARMLoginViewModel _viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ARMLoginDialogView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public ARMLoginDialogView(IARMLoginViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            _viewModel.CloseAction = CloseDlg;
            Dispatcher.BeginInvoke((Action)(() => this.DataContext = _viewModel));
        }

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        /// <param name="res">if set to <c>true</c> [resource].</param>
        private void CloseDlg(bool res)
        {
            DialogResult = res;
            Close();
        }
    }
}