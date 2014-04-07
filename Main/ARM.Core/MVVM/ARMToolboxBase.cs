using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using ARM.Core.Enums;
using ARM.Core.Interfaces;
using ARM.Core.MVVM;
using ARM.Core.MVVM.Commands;

namespace ARM.Core.MVVM
{
    public class ARMToolboxBase : ARMViewModelBase, IARMToolboxViewModel
    {
        protected readonly ObservableCollection<IARMToolboxCommand> CmdList = new ObservableCollection<IARMToolboxCommand>();

        protected Action<ToolbarCommand> InternalAction;
        protected Func<ToolbarCommand, bool> InternalPredicate; 


        public ARMToolboxBase(IARMToolboxView view)
            : base(view)
        {
        }

        public IEnumerable<IARMToolboxCommand> Commands { get { return CmdList.OrderBy(c => c.Order).AsEnumerable(); } }
        
        public void InitializeCommands()
        {
            InternalInitialize();
        }

        protected virtual void InternalInitialize()
        {
            CmdList.Add(new ARMToolboxAddCommand(InternalAction, InternalPredicate));
            CmdList.Add(new ARMToolboxEditCommand(InternalAction, InternalPredicate));
            CmdList.Add(new ARMToolboxDeleteCommand(InternalAction, InternalPredicate));
        }

        public void AddCommand(IARMToolboxCommand cmd)
        {
            CmdList.Add(cmd);
            OnPropertyChanged(() => Commands);
        }

        public void SetActions(Action<ToolbarCommand> action, Func<ToolbarCommand, bool> predicate)
        {
            InternalAction = action;
            InternalPredicate = predicate;
        }
    }
}