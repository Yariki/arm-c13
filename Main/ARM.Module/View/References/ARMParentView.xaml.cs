using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Представлення для роботи з батьками.
    /// </summary>
    public partial class ARMParentView : UserControl, IARMParentView
    {
        /// <summary>
        /// Створити екземпляр ARMParentView.
        /// </summary>
        public ARMParentView()
        {
            InitializeComponent();
        }
    }
}