using System;
using System.ComponentModel;
using System.Windows;
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
            if (_model != null)
                _model.OnClosing(e);
        }

        private void ModelOnClose(object sender, EventArgs eventArgs)
        {
            Close();
        }
    }
}