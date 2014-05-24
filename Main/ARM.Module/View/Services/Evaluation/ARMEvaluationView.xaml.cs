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
using ARM.Module.Interfaces.Services.Evaluation.View;

namespace ARM.Module.View.Services.Evaluation
{
    /// <summary>
    /// Представлення для роботи з сервісом оцінування студентів.
    /// </summary>
    public partial class ARMEvaluationView : UserControl, IARMEvaluationView
    {
        /// <summary>
        /// Створити екземпляр ARMEvaluationView.
        /// </summary>
        public ARMEvaluationView()
        {
            InitializeComponent();
        }
    }
}
