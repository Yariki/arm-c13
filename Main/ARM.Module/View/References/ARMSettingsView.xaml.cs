using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    ///    Представлення для роботи з налаштуваннями.
    /// </summary>
    public partial class ARMSettingsView : UserControl, IARMSettingsView
    {
        /// <summary>
        /// Створити екземпляр <see cref="ARMSettingsView"/> class.
        /// </summary>
        public ARMSettingsView()
        {
            InitializeComponent();
        }
    }
}