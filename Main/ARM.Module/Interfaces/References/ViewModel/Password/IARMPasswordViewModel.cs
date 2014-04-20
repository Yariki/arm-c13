using System.ComponentModel;
using System.Runtime.CompilerServices;
using ARM.Core.Interfaces;

namespace ARM.Module.Interfaces.References.ViewModel.Password
{
    public interface IARMPasswordViewModel : IARMDataViewModel,IDataErrorInfo
    {
        string Password1 { get; set; }
        string Password2 { get; set; }
    }
    
}