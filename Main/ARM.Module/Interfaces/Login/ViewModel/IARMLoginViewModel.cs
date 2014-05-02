using System;
using ARM.Core.Interfaces;
using ARM.Data.Models;
using ARM.Infrastructure.Controls.Interfaces;

namespace ARM.Module.Interfaces.Login.ViewModel
{
    public interface IARMLoginViewModel : IARMValidatableViewModel, IARMDialogViewModel
    {
        Action<bool> CloseAction { get; set; }
        bool IsUserValid { get; }
        User GetUser();
        eARMSystemLanguage Language  {get;}
    }
}