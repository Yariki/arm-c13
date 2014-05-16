using System.Windows;
using ARM.Infrastructure.Interfaces;

namespace ARM.Infrastructure.Utils
{
    public class ARMMessageFacade : IARMMessageBoxFacade
    {
        private readonly string WarningCaption;
        private readonly string ErrorCaption;
        private readonly string QuestionCaption;
        private readonly string InformationMessage;

        public ARMMessageFacade()
        {
            WarningCaption = Resource.AppResource.Resources.Message_WarningCaption;
            ErrorCaption = Resource.AppResource.Resources.Message_ErrorCaprion;
            QuestionCaption = Resource.AppResource.Resources.Message_QuestionCaption;
            InformationMessage = Resource.AppResource.Resources.Message_InformationCaption;
        }

        public MessageBoxResult Show(string message)
        {
            return MessageBox.Show(message, InformationMessage, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public MessageBoxResult ShowWarning(string message)
        {
            return MessageBox.Show(message, WarningCaption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public MessageBoxResult ShowQuestion(string message)
        {
            return MessageBox.Show(message, QuestionCaption, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        }

        public MessageBoxResult ShowError(string message)
        {
            return MessageBox.Show(message, ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}