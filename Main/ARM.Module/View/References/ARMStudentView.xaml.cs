using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Представлення для роботи з студентами.
    /// </summary>
    public partial class ARMStudentView : UserControl, IARMStudentView
    {
        /// <summary>
        /// Створити екземпляр ARMStudentView.
        /// </summary>
        public ARMStudentView()
        {
            InitializeComponent();
        }
    }
}