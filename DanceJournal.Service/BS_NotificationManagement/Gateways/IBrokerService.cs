using DanceJournal.Services.BS_NotificationManagement.Contracts;

namespace DanceJournal.Services.BS_NotificationManagement.Gateways
{
    public interface IBrokerService
    {
        void Subscribe();
        void PublishNotificationMessage(NotificationMessageDTO notificationMessageDTO);
    }
}
