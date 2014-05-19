using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ARM.Module.Interfaces.Documents.View;

namespace ARM.Module.View.Documents
{
    /// <summary>
    /// Преставлення дла роботи з контрактами.
    /// </summary>
    public partial class ARMContractView : UserControl,IARMContractView
    {
        /// <summary>
        /// Створення екземпляру.
        /// </summary>
        public ARMContractView()
        {
            InitializeComponent();
        }
    }
}
