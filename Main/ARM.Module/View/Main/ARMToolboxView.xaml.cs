﻿using System.Windows.Controls;
using ARM.Module.Interfaces.View;

namespace ARM.Module.View.Main
{
    /// <summary>
    ///     Interaction logic for ARMToolboxView.xaml
    /// </summary>
    public partial class ARMToolboxView : UserControl, IARMMainToolboxView
    {
        public ARMToolboxView()
        {
            InitializeComponent();
        }
    }
}