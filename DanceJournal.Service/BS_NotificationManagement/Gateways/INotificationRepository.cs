using DanceJournal.Service.BS_NotificationManagement.Entities;

namespace DanceJournal.Service.BS_NotificationManagement.Gateways
{
    public interface INotificationRepository
    {
        Task<List<InvitationNotificationStatus>> GetAllInvitationNotificationStatuses();

        Task<bool> UpdateInvitationNotificationStatus(
            InvitationNotificationStatus invitationNotificationStatus
        );

        Task<Invitation?> GetInvitation(int invitationId);
    }
}
