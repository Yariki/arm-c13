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
using ARM.Module.Interfaces.Documents.View;

namespace ARM.Module.View.Documents
{
    /// <summary>
    /// Interaction logic for ARMInvoiceView.xaml
    /// </summary>
    public partial class ARMInvoiceView : UserControl,IARMInvoiceView
    {
        public ARMInvoiceView()
        {
            InitializeComponent();
        }
    }
}