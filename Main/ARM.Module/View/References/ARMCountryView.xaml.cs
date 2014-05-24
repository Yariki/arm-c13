using System.Windows.Controls;
using ARM.Module.Interfaces.References.View;

namespace ARM.Module.View.References
{
    /// <summary>
    ///     Представлення для роботи країнами.
    /// </summary>
    public partial class ARMCountryView : UserControl, IARMCountryView
    {
        /// <summary>
        /// Створити екземпляр ARMCountryView.
        /// </summary>
        public ARMCountryView()
        {
            InitializeComponent();
        }
    }
}