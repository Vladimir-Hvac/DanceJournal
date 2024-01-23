using DanceJournal.Services.BS_NotificationManagement.Entities;
using DanceJournal.Services.BS_NotificationManagement.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
