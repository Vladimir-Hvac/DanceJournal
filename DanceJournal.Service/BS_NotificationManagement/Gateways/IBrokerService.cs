using DanceJournal.Contracts.MessageContracts;

namespace DanceJournal.Services.BS_NotificationManagement.Gateways
{
    public interface IBrokerService
    {
        void PublishNotificationMessage(NotificationMessageDTO notificationMessageDTO);
    }
}
