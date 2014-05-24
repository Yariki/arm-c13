using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Представлення для роботи з мовами.
    /// </summary>
    public partial class ARMLanguageView : UserControl, IARMLanguageView
    {
        /// <summary>
        /// Створити екземпляр ARMLanguageView.
        /// </summary>
        public ARMLanguageView()
        {
            InitializeComponent();
        }
    }
}