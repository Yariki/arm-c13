using System;
using System.Windows;
using ARM.Infrastructure.Controls.Interfaces;

namespace ARM.Infrastructure.Controls.ARMDialogWindow
{
    /// <summary>
    /// Простір імен для базового діалогового вікна.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {
    }

    /// <summary>
    /// Логіка взаємодії для ARMWindow.xaml
    /// </summary>
    public partial class ARMDialogWindow : Window
    {
        private IARMDialogViewModel _viewModel;

        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMDialogWindow"/>.
        /// </summary>
        /// <param name="viewModel">Модель представлення.</param>
        public ARMDialogWindow(IARMDialogViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            Dispatcher.BeginInvoke((Action)(() => this.DataContext = _viewModel));
        }

        /// <summary>
        /// Обробляє подія OnClick елемента управління ButtonBase.
        /// </summary>
        /// <param name="sender">Відправник.</param>
        /// <param name="e">Аргументи.</param>
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (!_viewModel.Validate())
                return;
            DialogResult = true;
            Close();
        }
        /// <summary>
        /// Обробляє подія OnClick елемента управління ButtonBase.
        /// </summary>
        /// <param name="sender">Відправник.</param>
        /// <param name="e">Аргументи.</param>
        private void ButtonBase_CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}