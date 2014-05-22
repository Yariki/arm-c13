using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Представлення для робота з заняттями.
    /// </summary>
    public partial class ARMClassView : UserControl, IARMClassView
    {
        /// <summary>
        /// Створити екземпляр ARMClassView.
        /// </summary>
        public ARMClassView()
        {
            InitializeComponent();
        }
    }
}