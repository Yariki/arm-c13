using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    ///    Представлення для роботи з персоналом.
    /// </summary>
    public partial class ARMStaffView : UserControl, IARMStaffView
    {
        /// <summary>
        /// Створити екземпляр ARMStaffView.
        /// </summary>
        public ARMStaffView()
        {
            InitializeComponent();
        }
    }
}