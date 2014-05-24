using System;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Wpf.DataGrid;

namespace ARM.Infrastructure.Controls.Filter
{
    /// <summary>
    /// Ячейка для вводу значення фільтра для сітки.
    /// </summary>
    public class ARMFilterCell : Cell
    {
        #region [needs]

        private TextBox _textBox;
        private ColumnBase _column;
        #endregion

        /// <summary>
        /// Виконується при оновлення критерії.
        /// </summary>
        public event EventHandler<ARMApplyCritetiaEventArgs> ApplyCriteria;

        protected virtual void OnApplyCriteria(ARMApplyCritetiaEventArgs e)
        {
            EventHandler<ARMApplyCritetiaEventArgs> handler = ApplyCriteria;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Створити екземпляр <see cref="ARMFilterCell"/> class.
        /// </summary>
        /// <param name="column">The column.</param>
        public ARMFilterCell(ColumnBase column )
        {
            _column = column;
            _textBox = new TextBox();
            Content = _textBox;
            _textBox.KeyDown += TextBoxOnKeyDown;
        }

        private void TextBoxOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.Key)
            {
                case Key.Enter:
                    OnApplyCriteria(new ARMApplyCritetiaEventArgs()
                    {
                        PropertyName = _column.FieldName,Value = _textBox.Text
                    }); 
                    break;
            }
        }

    }
}