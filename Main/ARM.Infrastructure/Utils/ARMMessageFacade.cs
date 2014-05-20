using System.Windows;
using ARM.Infrastructure.Interfaces;

namespace ARM.Infrastructure.Utils
{
    /// <summary>
    /// Клас, призначений для для виводу повідомлень.
    /// </summary>
    public class ARMMessageFacade : IARMMessageBoxFacade
    {
        private readonly string WarningCaption;
        private readonly string ErrorCaption;
        private readonly string QuestionCaption;
        private readonly string InformationMessage;

        /// <summary>
        /// Ініціалізує новий екземпляр класу <see cref="ARMMessageFacade"/>.
        /// </summary>
        public ARMMessageFacade()
        {
            WarningCaption = Resource.AppResource.Resources.Message_WarningCaption;
            ErrorCaption = Resource.AppResource.Resources.Message_ErrorCaprion;
            QuestionCaption = Resource.AppResource.Resources.Message_QuestionCaption;
            InformationMessage = Resource.AppResource.Resources.Message_InformationCaption;
        }

        /// <summary>
        /// Показує вказане повідомлення.
        /// </summary>
        /// <param name="message">Повідомлення.</param>
        /// <returns></returns>
        public MessageBoxResult Show(string message)
        {
            return MessageBox.Show(message, InformationMessage, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Показує попередження.
        /// </summary>
        /// <param name="message">Повідомлення.</param>
        /// <returns></returns>
        public MessageBoxResult ShowWarning(string message)
        {
            return MessageBox.Show(message, WarningCaption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// Показує повідомлення з запитанням.
        /// </summary>
        /// <param name="message">Повідомлення.</param>
        /// <returns></returns>
        public MessageBoxResult ShowQuestion(string message)
        {
            return MessageBox.Show(message, QuestionCaption, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        }

        /// <summary>
        /// Показує повідомлення про помилку.
        /// </summary>
        /// <param name="message">Повідомлення.</param>
        /// <returns></returns>
        public MessageBoxResult ShowError(string message)
        {
            return MessageBox.Show(message, ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}