using System;
using System.ComponentModel;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using ARM.Core.Enums;
using ARM.Core.Interfaces.Data;
using ARM.Core.Module;
using ARM.Data.Sevice.Resolver;
using ARM.Infrastructure.Annotations;
using ARM.Infrastructure.Controls.Interfaces;
using Microsoft.Practices.Unity;

namespace ARM.Infrastructure.Controls.ARMLookupControl
{

    [TemplatePart(Name = "PART_TextBoxValue", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_ButtonWnd", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ButtonWndClear", Type = typeof(Button))]
    public class ARMLookupControl : Control, INotifyPropertyChanged
    {
        #region [needs]

        public static string PART_TextBox = "PART_TextBoxValue";
        public static string PART_Button = "PART_ButtonWnd";
        public static string PART_ButtonClear = "PART_ButtonWndClear";
        
        private TextBox _textBox;
        private Button _button;
        private Button _buttonClear;

        private IARMModel _model;

        #endregion


        #region [ctor]

        public ARMLookupControl()
            :base()
        {
            
        }

        static ARMLookupControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ARMLookupControl), new FrameworkPropertyMetadata(typeof(ARMLookupControl)));
        }

        #endregion

        #region [oveeride]

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _textBox = GetTemplateChild(PART_TextBox) as TextBox;
            _button = GetTemplateChild(PART_Button) as Button;
            _buttonClear = GetTemplateChild(PART_ButtonClear) as Button;
            if (_button != null)
            {
                _button.Click += ButtonOnClick;
            }

            if (_buttonClear != null)
            {
                _buttonClear.Click += ButtonClearOnClick;
            }
            if(_model != null && _textBox != null)
            {
                _textBox.Text = _model.ToString();
            }
        }

        #endregion


        #region [depedency property]

        public static readonly DependencyProperty UnityContainerProperty = DependencyProperty.Register(
            "UnityContainer", typeof (IUnityContainer), typeof (ARMLookupControl), new PropertyMetadata(default(IUnityContainer)));

        public IUnityContainer UnityContainer
        {
            get { return (IUnityContainer) GetValue(UnityContainerProperty); }
            set { SetValue(UnityContainerProperty, value); }
        }

        public static readonly DependencyProperty MetadataProperty = DependencyProperty.Register(
            "Metadata", typeof (eARMMetadata), typeof (ARMLookupControl), new PropertyMetadata(default(eARMMetadata)));

        public eARMMetadata Metadata
        {
            get { return (eARMMetadata) GetValue(MetadataProperty); }
            set { SetValue(MetadataProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof (Guid), typeof (ARMLookupControl), new PropertyMetadata(default(Guid),ValueOnChangeCallback));

        private static void ValueOnChangeCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var ctrl = dependencyObject as ARMLookupControl;
            if(ctrl == null)
                return;
            ctrl.ValueChanged(dependencyPropertyChangedEventArgs);

        }

        public Guid Value
        {
            get { return (Guid) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        
        #endregion

        #region [public]

        public void ValueChanged(DependencyPropertyChangedEventArgs args)
        {
            if(args.OldValue == args.NewValue)
                return;
            System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(
                (Action) (() => ApplyValue((Guid) args.NewValue)));
        }

        #endregion

        #region [private]

        private void ApplyValue(Guid id)
        {
            if (UnityContainer == null)
                return;
            var resolver = UnityContainer.Resolve<IARMDataModelResolver>();
            if (resolver == null)
                return;
            _model = resolver.GetDataModel(Metadata, id) as IARMModel;
            if (_model == null || _textBox == null)
            {
                return;
            }
            _textBox.Text = _model.ToString();
        }


        private void ButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            IARMLookupViewModel viewModel = new ARMLookupViewModel(UnityContainer,new ARMLookupView());
            viewModel.Initialize(Metadata);
            ARMLookupWindow.ARMLookupWindow wnd = new ARMLookupWindow.ARMLookupWindow(viewModel);

            var result = wnd.ShowDialog();
            if (result.HasValue && result.Value)
            {
                _textBox.Text = viewModel.SelectedItem.ToString();
                Value = (viewModel.SelectedItem as IARMModel).Id;
                OnPropertyChanged("Value");
            }
        }


        private void ButtonClearOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Value = Guid.Empty;
            _textBox.Text = string.Empty;
            OnPropertyChanged("Value");
        }

        

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}