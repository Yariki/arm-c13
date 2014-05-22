using ARM.Module.Interfaces.Services.CalculationStipend.View;
using System.Windows.Controls;

namespace ARM.Module.View.Services.CalculaltionStipend
{
    /// <summary>
    /// Представлення для роботи з сервісом розрахунку стипендій.
    /// </summary>
    public partial class ARMCalculationStipendView : UserControl, IARMCalculationStipendView
    {
        /// <summary>
        /// Створити екземпляр ARMCalculationStipendView.
        /// </summary>
        public ARMCalculationStipendView()
        {
            InitializeComponent();
        }
    }
}