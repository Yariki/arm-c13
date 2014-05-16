﻿///////////////////////////////////////////////////////////
//  ARMToolboxEditCommand.cs
//  Implementation of the Class ARMToolboxEditCommand
//  Generated by Enterprise Architect
//  Created on:      01-Apr-2014 12:36:35 AM
///////////////////////////////////////////////////////////

using System;
using ARM.Core.Enums;
using ARM.Core.MVVM.Commands.Base;

namespace ARM.Core.MVVM.Commands
{
  /// <summary>
  /// Команда для запуску редагування запису
  /// </summary>
    public class ARMToolboxEditCommand : ARMToolboxCommandBase
    {
      /// <summary>
      /// Ініціалізує новий екземпляр класу <see cref="ARMToolboxEditCommand"/>.
      /// </summary>
      /// <param name="action">Дія.</param>
      /// <param name="predicate">Предикат.</param>
        public ARMToolboxEditCommand(Action<ToolbarCommand> action, Func<ToolbarCommand, bool> predicate) 
            : base(action, predicate)
        {
            Type = ToolbarCommand.Edit;
            Title = "Edit";
        }

        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMToolboxEditCommand"/>.
        /// </summary>
        /// <param name="action">Дія.</param>
        public ARMToolboxEditCommand(Action<ToolbarCommand> action) 
            : this(action,null)
        {

        }
    }//end ARMToolboxEditCommand
}//end namespace Commands