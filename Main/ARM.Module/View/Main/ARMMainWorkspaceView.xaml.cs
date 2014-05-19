using System.Windows.Controls;
using ARM.Module.Interfaces.View;

namespace ARM.Module.View.Main
{
    /// <summary>
    /// Головне представлення програми.
    /// Воно містить TabControl в якому створюються вкладки для кожної операції, документа,
    /// журналу, звіту.
    /// </summary>
    public partial class ARMMainWorkspaceView : UserControl, IARMMainWorkspaceView
    {

        /// <summary>
        /// Створити екземпляр ARMMainWorkspaceView.
        /// </summary>
        public ARMMainWorkspaceView()
        {
            InitializeComponent();
        }
    }
}