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
using ARM.Module.Interfaces.Services.Mark.View;

namespace ARM.Module.View.Services.Mark
{
    /// <summary>
    /// Форма для робота з оцінками.
    /// </summary>
    public partial class ARMMarkView : UserControl,IARMMarkView
    {
        /// <summary>
        /// Створити екземпляр ARMMarkView.
        /// </summary>
        public ARMMarkView()
        {
            InitializeComponent();
        }
    }
}
