using System;
using ARM.Core.Interfaces;
using ARM.Infrastructure.Controls.Interfaces;

namespace ARM.Module.Interfaces.Services.Mark.ViewModel
{
    /// <summary>
    /// Інтерфейс моделі прпедставлення дл оцінок.
    /// </summary>
    public interface IARMMarkValidatableViewModel : IARMValidatableViewModel,IARMDialogViewModel
    {
        /// <summary>
        /// Вставновити студента.
        /// </summary>
        /// <param name="id">Ідентифікатор.</param>
        void SetStudent(Guid? id);
        /// <summary>
        /// Встановити клас.
        /// </summary>
        /// <param name="id">Ідентифікатор.</param>
        void SetClass(Guid? id);
    }
}