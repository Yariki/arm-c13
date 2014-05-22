using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Представлення для роботи з спеціальностями
    /// </summary>
    public partial class ARMSpecialityView : UserControl, IARMSpecialityView
    {
        /// <summary>
        /// Створити екземпляр ARMSpecialityView.
        /// </summary>
        public ARMSpecialityView()
        {
            InitializeComponent();
        }
    }
}