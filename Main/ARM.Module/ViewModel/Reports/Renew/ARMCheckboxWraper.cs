using System.ComponentModel;
using ARM.Data.Models;
using ARM.Infrastructure.Annotations;

namespace ARM.Module.ViewModel.Reports.Renew
{
    public class ARMCheckboxWraper<T> : INotifyPropertyChanged  where T : BaseModel
    {
        private bool _isSelected;

        private T _object;
        public ARMCheckboxWraper(T obj)
        {
            _object = obj;
        }

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public string Display { get { return _object.Display; } }
        public T Value { get { return _object; } }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}