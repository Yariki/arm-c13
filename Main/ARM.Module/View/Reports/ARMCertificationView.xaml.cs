using System.Windows.Controls;
using ARM.Module.Interfaces.Reports.View;

namespace ARM.Module.View.Reports
{
    /// <summary>
    /// Представлення для роботи з звітом атестації
    /// </summary>
    public partial class ARMCertificationView : UserControl, IARMCertificationView
    {
        /// <summary>
        /// Створити екземпляр ARMCertificationView.
        /// </summary>
        public ARMCertificationView()
        {
            InitializeComponent();
        }
    }
}