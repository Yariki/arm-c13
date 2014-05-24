using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ARM.Core.Enums;
using ARM.Core.Interfaces.Data;
using ARM.Data.Sevice.Resolver;
using ARM.Infrastructure.Annotations;
using ARM.Infrastructure.Controls.ARMLookupWindow;
using ARM.Infrastructure.Controls.Interfaces;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;

namespace ARM.Infrastructure.Controls.ARMLookupControl
{
    /// <summary>
    /// Елемент управління для представлення обєкту даних за його ідентифікатором.
    /// Даний елемент управляння приймає тип даних та його ідентифікатором він визначає:
    /// 1. Який клас доступу до даних використовувати.
    /// 2. Метод відображення даних.
    /// Також він призначений ддл вибору подібних елементів и може бути првязаний до обєкту даних,
    /// для редагування його властивостей.
    /// </summary>
    [TemplatePart(Name = "PART_TextBoxValue", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_ButtonWnd", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ButtonWndClear", Type = typeof(Button))]
    public class ARMLookupControl : Control, INotifyPropertyChanged
    {
        #region [const]

        #endregion [const]

        #region [needs]

        public static string PART_TextBox = "PART_TextBoxValue";
        public static string PART_Button = "PART_ButtonWnd";
        public static string PART_ButtonClear = "PART_ButtonWndClear";

        private TextBox _textBox;
        private Button _button;
        private Button _buttonClear;

        private IARMModel _model;

        #endregion [needs]

        #region [ctor]

        /// <summary>
        /// Створити екземпляр ARMLookupControl.
        /// </summary>
        public ARMLookupControl()
            : base()
        {
        }

        static ARMLookupControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ARMLookupControl), new FrameworkPropertyMetadata(typeof(ARMLookupControl)));
        }

        #endregion [ctor]

        #region [oveeride]

        /// <summary>
        /// При перевизначенні в похідному класі викликається кожного разу, коли код програми або внутрішні процеси викликають <see cref="M:System.Windows.FrameworkElement.ApplyTemplate" />.
        /// </summary>
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
            if (_model != null && _textBox != null)
            {
                _textBox.Text = _model.ToString();
            }
        }

        #endregion [oveeride]

        #region [depedency property]

        public static readonly DependencyProperty UnityContainerProperty = DependencyProperty.Register(
            "UnityContainer", typeof(IUnityContainer), typeof(ARMLookupControl), new PropertyMetadata(default(IUnityContainer)));

        /// <summary>
        /// Отримує або задає IoC контейнер.
        /// </summary>
        public IUnityContainer UnityContainer
        {
            get { return (IUnityContainer)GetValue(UnityContainerProperty); }
            set { SetValue(UnityContainerProperty, value); }
        }

        public static readonly DependencyProperty MetadataProperty = DependencyProperty.Register(
            "Metadata", typeof(eARMMetadata), typeof(ARMLookupControl), new PropertyMetadata(default(eARMMetadata)));

        /// <summary>
        /// Отримує або задає метадані.
        /// </summary>
        public eARMMetadata Metadata
        {
            get { return (eARMMetadata)GetValue(MetadataProperty); }
            set { SetValue(MetadataProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(Guid), typeof(ARMLookupControl), new PropertyMetadata(Guid.Empty, ValueOnChangeCallback));

        /// <summary>
        /// Отримує або задає значення.
        /// </summary>
        public Guid Value
        {
            get { return (Guid)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static void ValueOnChangeCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var ctrl = dependencyObject as ARMLookupControl;
            if (ctrl == null)
                return;
            ctrl.ValueChanged(dependencyPropertyChangedEventArgs);
        }

        public static readonly DependencyProperty IsIdEmptyProperty = DependencyProperty.Register(
            "IsIdEmpty", typeof(bool), typeof(ARMLookupControl), new PropertyMetadata(false));

        public bool IsIdEmpty
        {
            get { return (bool)GetValue(IsIdEmptyProperty); }
            set { SetValue(IsIdEmptyProperty, value); }
        }

        #endregion [depedency property]

        #region [public]

        public void ValueChanged(DependencyPropertyChangedEventArgs args)
        {
            System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(
                (Action)(() => ApplyValue((Guid)args.NewValue)));
        }

        #endregion [public]

        #region [private]

        private void ApplyValue(Guid id)
        {
            if (UnityContainer == null)
                return;
            var resolver = UnityContainer.Resolve<IARMDataModelResolver>();
            if (resolver == null)
                return;
            _model = resolver.GetDataModel(Metadata, id, IsIdEmpty) as IARMModel;
            if (_model == null || _textBox == null)
            {
                return;
            }
            _textBox.Text = _model.ToString();
        }

        private void ButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            IARMLookupViewModel viewModel = new ARMLookupViewModel(UnityContainer, UnityContainer.Resolve<IEventAggregator>(), new ARMLookupView());
            viewModel.Initialize(Metadata);
            ARMLookupWindow.ARMLookupWindow wnd = new ARMLookupWindow.ARMLookupWindow(viewModel);

            var result = wnd.ShowDialog();
            if (result.HasValue && result.Value && viewModel.SelectedItem != null)
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

        #endregion [private]

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}