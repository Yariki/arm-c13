using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Представлення для роботи з факультетами.
    /// </summary>
    public partial class ARMFacultyView : UserControl, IARMFacultyView
    {
        /// <summary>
        /// Створити екземпляр ARMFacultyView.
        /// </summary>
        public ARMFacultyView()
        {
            InitializeComponent();
        }
    }
}