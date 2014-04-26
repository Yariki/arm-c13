///////////////////////////////////////////////////////////
//  ARMMainMenuViewModel.cs
//  Implementation of the Class ARMMainMenuViewModel
//  Generated by Enterprise Architect
//  Created on:      02-Apr-2014 1:17:47 AM
///////////////////////////////////////////////////////////

using System;
using System.Collections.ObjectModel;
using ARM.Core.MVVM;
using ARM.Module.Commands.Menu.Documents;
using ARM.Module.Commands.Menu.File;
using ARM.Module.Commands.Menu.Reference;
using ARM.Module.Enums;
using ARM.Module.Interfaces;
using ARM.Module.Interfaces.View;

namespace ARM.Module.ViewModel.Main
{
    public class ARMMainMenuViewModel : ARMViewModelBase, IARMMainMenuViewModel
    {
        private Action<eARMMainMenuCommand> _actionMenu;
        private Func<eARMMainMenuCommand, bool> _canFunc;

        public ARMMainMenuViewModel(IARMMainMenuView menuView)
            : base(menuView)
        {
        }

        public ObservableCollection<IARMMenuCommand> Files { get; private set; }

        public ObservableCollection<IARMMenuCommand> Documents { get; private set; }

        public ObservableCollection<IARMMenuCommand> References { get; private set; }

        public ObservableCollection<IARMMenuCommand> Reports { get; private set; }

        public ObservableCollection<IARMMenuCommand> Services { get; private set; }

        public ObservableCollection<IARMMenuCommand> Helps { get; private set; }

        public void InitializeCommands()
        {
            InitFile();
        }

        public void SetActions(Action<eARMMainMenuCommand> actionMenu, Func<eARMMainMenuCommand, bool> canPredicate)
        {
            _actionMenu = actionMenu;
            _canFunc = canPredicate;
        }

        #region [private]

        private void InitFile()
        {
            Files = new ObservableCollection<IARMMenuCommand>();
            Files.Add(new ARMMenuExitCommand(_actionMenu, _canFunc));

            References = new ObservableCollection<IARMMenuCommand>();
            References.Add(new ARMMenuUniversityCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuFacultyCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuSpecialityCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuSessionCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuClassCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuGroupCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuStaffCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuStudentCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuLanguageCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuCountryCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuParentCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuAddressCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuUserCommand(_actionMenu, _canFunc));
            References.Add(new ARMMenuSettingsCommand(_actionMenu, _canFunc));

            Documents = new ObservableCollection<IARMMenuCommand>();
            Documents.Add(new ARMMenuContractCommand(_actionMenu,_canFunc));
        }

        #endregion [private]
    }//end ARMMainMenuViewModel
}//end namespace Main