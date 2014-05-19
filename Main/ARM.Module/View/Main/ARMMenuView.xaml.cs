using System.Windows.Controls;
using ARM.Module.Interfaces.View;

namespace ARM.Module.View.Main
{
    /// <summary>
    ///     Представлення для головного меню програми. В ньому описано вигляд меню та додана привязка до колекцій команд.
    /// </summary>
    public partial class ARMMenuView : UserControl, IARMMainMenuView
    {
        /// <summary>
        /// Створити екземпляр ARMMenuView.
        /// </summary>
        public ARMMenuView()
        {
            InitializeComponent();
        }
    }
}