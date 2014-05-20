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
using ARM.Module.Interfaces.Login.View;

namespace ARM.Module.View.Login.View
{
    /// <summary>
    /// Преставлення дла роботи з логіном.
    /// </summary>
    public partial class ARMLoginView : UserControl, IARMLoginView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ARMLoginView"/> class.
        /// </summary>
        public ARMLoginView()
        {
            InitializeComponent();
        }
    }
}
