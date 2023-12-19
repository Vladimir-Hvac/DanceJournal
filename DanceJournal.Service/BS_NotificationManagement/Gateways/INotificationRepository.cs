using DanceJournal.Service.BS_NotificationManagement.Entities;

namespace DanceJournal.Service.BS_NotificationManagement.Gateways
{
    public interface INotificationRepository
    {
        Task<List<NotificationReadingStatus>> GetAllNotificationReadingStatuses();

        Task<List<InvitationNotificationStatus>> GetAllInvitationNotificationStatuses();
    }
}
