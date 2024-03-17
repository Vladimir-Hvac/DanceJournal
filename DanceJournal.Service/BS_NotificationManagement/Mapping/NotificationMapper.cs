using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement.Contracts;

namespace DanceJournal.Services.BS_NotificationManagement.Mapping
{
    public static class NotificationMapper
    {
        public static List<NotificationDTO> MapNotificationDTOs(List<(NotificationStatus, InvitationStatus?)> notificInvStatuses)
        {
            List<NotificationDTO> notificationDTOs = new();
            foreach (var notifInv in notificInvStatuses)
            {
                notificationDTOs.Add(MapNotificationDTO(notifInv.Item1, notifInv.Item2));
            }
            return notificationDTOs;
        }

        public static NotificationDTO MapNotificationDTO(NotificationStatus notificationStatus, InvitationStatus? invitationStatus)
        {
            NotificationDTO result = new();

            if (notificationStatus.Notification == null)
            {
                return result;
            }

            result.Id = notificationStatus.Notification.Id;
            result.ReceiverId = notificationStatus.ReceiverId;
            result.Body = notificationStatus.Notification.Body;

            result.Date = DateOnly.FromDateTime(notificationStatus.Notification.CreationTime);
            result.Time = TimeOnly.FromDateTime(notificationStatus.Notification.CreationTime);

            if (notificationStatus.Notification.Creator != null)
            {
                result.Creator = notificationStatus.Notification.Creator;
            }
            if (invitationStatus != null && invitationStatus.Invitation != null)
            {
                result.Invitation = InvitationMapper.MapInvitationDTO(invitationStatus);
            }
            return result;
        }
    }
}
