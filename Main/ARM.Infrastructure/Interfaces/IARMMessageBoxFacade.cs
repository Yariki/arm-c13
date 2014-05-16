///////////////////////////////////////////////////////////
//  IARMMessageBoxFacade.cs
//  Implementation of the Interface IARMMessageBoxFacade
//  Generated by Enterprise Architect
//  Created on:      30-Mar-2014 8:12:16 PM
///////////////////////////////////////////////////////////

using System.Windows;

namespace ARM.Infrastructure.Interfaces
{
    public interface IARMMessageBoxFacade
    {
        MessageBoxResult Show(string message);

        MessageBoxResult ShowWarning(string message);

        MessageBoxResult ShowQuestion(string message);

        MessageBoxResult ShowError(string message);
    } //end IARMMessageBoxFacade
} //end namespace Interfaces