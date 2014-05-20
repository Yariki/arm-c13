﻿using System;
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
using ARM.Module.Interfaces.Reports.View;

namespace ARM.Module.View.Reports
{
    /// <summary>
    /// Interaction logic for ARMSessionMarksView.xaml
    /// </summary>
    public partial class ARMSessionMarksView : UserControl, IARMSessionMarksView
    {
        public ARMSessionMarksView()
        {
            InitializeComponent();
        }
    }
}