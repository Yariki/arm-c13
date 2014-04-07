using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ARM.Module.Interfaces;

namespace ARM.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {

        private IARMMainWorkspaceViewModel _model;

        public MainWindow()
        {
            InitializeComponent();
        }

        public IARMMainWorkspaceViewModel Model
        {
            get { return _model; }
            set
            {
                _model = value; 
                _model.Close += ModelOnClose;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _model.OnClosing(e);
        }

        private void ModelOnClose(object sender, EventArgs eventArgs)
        {
            Close();
        }
    }
}
