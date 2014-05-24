using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Представлення для роботи з групами.
    /// </summary>
    public partial class ARMGroupView : UserControl, IARMGroupView
    {
        /// <summary>
        /// Створити екземпляр ARMGroupView.
        /// </summary>
        public ARMGroupView()
        {
            InitializeComponent();
        }
    }
}