using System.Windows.Controls;
using ARM.Module.Interfaces.View;

namespace ARM.Module.View.Main
{
    /// <summary>
    ///     Представлення для статус панелі.
    /// </summary>
    public partial class ARMStatusBarView : UserControl, IARMMainStatusBarView
    {
        /// <summary>
        /// Створити екземпляр ARMStatusBarView.
        /// </summary>
        public ARMStatusBarView()
        {
            InitializeComponent();
        }
    }
}