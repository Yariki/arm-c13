using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Представлення для роботи з університетами.
    /// </summary>
    public partial class ARMUniversityView : UserControl, IARMUniversityView
    {
        /// <summary>
        /// Створити екземпляр ARMUniversityView.
        /// </summary>
        public ARMUniversityView()
        {
            InitializeComponent();
        }
    }
}