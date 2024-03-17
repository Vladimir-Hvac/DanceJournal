using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement.Contracts;

namespace DanceJournal.Services.BS_NotificationManagement.Mapping
{
    internal class InvitationMapper
    {
        public static InvitationDTO MapInvitationDTO(InvitationStatus invitationStatus)
        {
            InvitationDTO result = new()
            {
                IsAccepted = invitationStatus.IsAccepted,
                IsDeclined = invitationStatus.IsDeclined,
            };
            if (invitationStatus.Invitation != null && invitationStatus.Invitation.Lesson != null)
            {
                result.Id = invitationStatus.Invitation.Id;
                result.Lesson = invitationStatus.Invitation.Lesson;
            }

            return result;
        }
    }
}
