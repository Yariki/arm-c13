using System.Windows.Controls;
using ARM.Infrastructure.Interfaces.Grid;

namespace ARM.Module.View.Grid
{
    /// <summary>
    ///    Преставлення дла роботи з сітками даних.
    /// </summary>
    public partial class ARMGridView : UserControl, IARMGridView
    {
        public ARMGridView()
        {
            InitializeComponent();
        }
    }
}