using System;
using ARM.Core.Interfaces;
using ARM.Infrastructure.Controls.Interfaces;

namespace ARM.Module.Interfaces.Services.Mark.ViewModel
{
    public interface IARMMarkValidatableViewModel : IARMValidatableViewModel,IARMDialogViewModel
    {
        void SetStudent(Guid? id);
        void SetClass(Guid? id);
    }
}