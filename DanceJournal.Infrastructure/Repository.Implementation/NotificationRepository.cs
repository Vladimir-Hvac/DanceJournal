using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement.Gateways;

namespace DanceJournal.Service.BS_NotificationManagement.Gateways
{
    public class NotificationRepository : INotificationRepository
    {
        public Task<List<InvitationNotificationStatus>> GetAllInvitationNotificationStatuses()
        {
            throw new NotImplementedException();
        }

        public Task<Invitation?> GetInvitation(int invitationId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateInvitationNotificationStatus(
            InvitationNotificationStatus invitationNotificationStatus
        )
        {
            throw new NotImplementedException();
        }
    }
}
