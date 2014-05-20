using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    /// Представлення для адрес.
    /// </summary>
    public partial class ARMAddressView : UserControl, IARMAddressView
    {
        /// <summary>
        /// Створити екземпляр ARMAddressView.
        /// </summary>
        public ARMAddressView()
        {
            InitializeComponent();
        }
    }
}