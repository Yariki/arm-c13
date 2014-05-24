using System.Windows.Controls;
using ARM.Module.Interfaces.Reports.View;

namespace ARM.Module.View.Reports
{
    /// <summary>
    /// Представлення для роботи з звітом по забборгованості.
    /// </summary>
    public partial class ARMDebtView : UserControl, IARMDebtView
    {
        /// <summary>
        /// Створити екземпляр ARMDebtView.
        /// </summary>
        public ARMDebtView()
        {
            InitializeComponent();
        }
    }
}