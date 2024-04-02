using DanceJournal.Contracts.MessageContracts;

namespace DanceJournal.MailClient
{
    public class MailClient
    {
        public void Execute(object? message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (message is NotificationMessageDTO m)
            {
                Console.WriteLine($"The MailClient recieved the message: {m.Message}");
            }
        }
    }
}
