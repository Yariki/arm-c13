using System.Windows.Input;
using ARM.Core.Interfaces;

namespace ARM.Infrastructure.Controls.Interfaces
{
    public interface IARMDialogViewModel : IARMViewModel
    {
        ICommand OkCommand { get; }

        ICommand CancelCommand { get; }

        bool Validate();
    }
}