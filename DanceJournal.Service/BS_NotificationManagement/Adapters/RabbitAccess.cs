using DanceJournal.Services.BS_NotificationManagement.Contracts;
using DanceJournal.Services.BS_NotificationManagement.Gateways;

namespace DanceJournal.Services.BS_NotificationManagement.Adapters
{
    public class RabbitAccess : IBrokerService
    {
        public void PublishNotificationMessage(NotificationMessageDTO notificationMessageDTO)
        {
            throw new NotImplementedException();
        }

        public void Subscribe()
        {
            throw new NotImplementedException();
        }
    }
}
