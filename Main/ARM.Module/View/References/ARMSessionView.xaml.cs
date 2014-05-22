using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Представлення для роботи з семестрами.
    /// </summary>
    public partial class ARMSessionView : UserControl, IARMSessionView
    {
        /// <summary>
        /// Створити екземпляр ARMSessionView.
        /// </summary>
        public ARMSessionView()
        {
            InitializeComponent();
        }
    }
}