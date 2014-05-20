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
using ARM.Infrastructure.Controls.Interfaces.View;
using ARM.Module.Interfaces.References.View.Password;

namespace ARM.Module.View.References.Password
{
    /// <summary>
    /// Предаставлення для паролів.
    /// </summary>
    public partial class ARMPasswordView : UserControl,IARMPasswordView,IARMDialogView
    {
        /// <summary>
        /// Створити екземпляр ARMPasswordView.
        /// </summary>
        public ARMPasswordView()
        {
            InitializeComponent();
        }
    }
}
