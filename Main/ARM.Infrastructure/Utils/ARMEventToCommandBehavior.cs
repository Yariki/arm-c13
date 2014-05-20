using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace ARM.Infrastructure.Utils
{
    /// <summary>
    /// Класс призначений для привязки певної команди до події, яка 
    /// проходить в певному обєкті.
    /// </summary>
    public class ARMEventToCommandBehavior : Behavior<FrameworkElement>
    {
        #region [need]

        private Delegate _handler;
        private EventInfo _oldEvent;

        #endregion [need]

        #region [ctor]

        /// <summary>
        /// Initializes a new instance of the <see cref="ARMEventToCommandBehavior"/> class.
        /// </summary>
        public ARMEventToCommandBehavior()
        {
        }

        #endregion [ctor]

        #region [property]

        public static DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand),
                                                                                       typeof(ARMEventToCommandBehavior),
                                                                                       new PropertyMetadata(null));

        /// <summary>
        /// Отримує або задає команду, яка буде викликатись.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static DependencyProperty PassArgumentsProperty = DependencyProperty.Register("PassArguments", typeof(bool),
                                                                                             typeof(
                                                                                               ARMEventToCommandBehavior),
                                                                                             new PropertyMetadata(false));

        /// <summary>
        /// Отримує або задає можливість передачі аргументів події в команду.
        /// </summary>
        public bool PassArguments
        {
            get { return (bool)GetValue(PassArgumentsProperty); }
            set { SetValue(PassArgumentsProperty, value); }
        }

        public static DependencyProperty PassSenderProperty = DependencyProperty.Register("PassSender", typeof(bool),
                                                                                             typeof(
                                                                                               ARMEventToCommandBehavior),
                                                                                             new PropertyMetadata(false));

        /// <summary>
        /// Отримує або задає можливість передачі відправника в команду.
        /// </summary>
        public bool PassSender
        {
            get { return (bool)GetValue(PassSenderProperty); }
            set { SetValue(PassSenderProperty, value); }
        }

        public static DependencyProperty EventProperty = DependencyProperty.Register("Event", typeof(string),
                                                                                     typeof(ARMEventToCommandBehavior),
                                                                                     new PropertyMetadata(null,
                                                                                                          OnEventChanged));

        /// <summary>
        /// Отримує або задає назву події до якої буде привязнано команду.
        /// </summary>
        public string Event
        {
            get { return (string)GetValue(EventProperty); }
            set { SetValue(EventProperty, value); }
        }

        /// <summary>
        /// Викликається при [зміни подія].
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void OnEventChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var beh = (ARMEventToCommandBehavior)o;
            if (beh != null && beh.AssociatedObject != null)
            {
                beh.AttachHandler((string)e.NewValue);
            }
        }

        #endregion [property]

        protected override void OnAttached()
        {
            this.AttachHandler(Event);
        }

        private void AttachHandler(string eventName)
        {
            if (_oldEvent != null)
            {
                _oldEvent.RemoveEventHandler(this.AssociatedObject, _handler);
            }
            if (!string.IsNullOrEmpty(Event))
            {
                EventInfo ei = this.AssociatedObject.GetType().GetEvent(eventName);
                if (ei != null)
                {
                    MethodInfo mi = this.GetType().GetMethod("ExecuteCommand", BindingFlags.Instance | BindingFlags.NonPublic);
                    _handler = Delegate.CreateDelegate(ei.EventHandlerType, this, mi);
                    ei.AddEventHandler(this.AssociatedObject, _handler);
                    _oldEvent = ei;
                }
            }
        }

        private void ExecuteCommand(object sender, EventArgs e)
        {
            if (Command != null && Command.CanExecute(null))
            {
                if (PassSender)
                {
                    Command.Execute(sender);
                }
                else
                {
                    Command.Execute(PassArguments ? e : null);
                }
            }
        }
    }
}