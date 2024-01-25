﻿using DanceJournal.Domain.Models;

namespace DanceJournal.Services.BS_NotificationManagement.Gateways
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
