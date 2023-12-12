using DanceJournal.Service.BS_NotificationManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Service.BS_NotificationManagement
{
    public interface INotificationService
    {
        List<NotificationDTO> GetNotReadNotifications(UserAuthData userAuthData);
        NotificationDTO ReadNotification(int notificationId);
        bool MarkAsRead(int notificationId);
        bool AcceptInvitation(int notificationId);
        bool DeclineInvitation(int notificationId);


        List<EventDTO> ProvideEvents(int userId);
        List<UserDTO> ProvideRecipients(int eventId);
        bool SentInvitation(int eventId, List<int> recipientsIds);
    }

    public class NotificationService
    {
    }
}
