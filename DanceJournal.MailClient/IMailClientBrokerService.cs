using DanceJournal.Contracts.MessageContracts;

namespace DanceJournal.MailClient
{
    internal interface IMailClientBrokerService
    {
        Action<NotificationMessageDTO> OnMessageRecieved { get; }
        void Subscribe();
    }
}
