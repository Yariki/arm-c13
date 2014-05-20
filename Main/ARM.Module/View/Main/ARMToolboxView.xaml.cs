using System.Windows.Controls;
using ARM.Module.Interfaces.View;

namespace ARM.Module.View.Main
{
    /// <summary>
    ///    Представлення для головної панелі управління.
    /// </summary>
    public partial class ARMToolboxView : UserControl, IARMMainToolboxView
    {
        /// <summary>
        /// Створити екземпляр ARMToolboxView.
        /// </summary>
        public ARMToolboxView()
        {
            InitializeComponent();
        }
    }
}