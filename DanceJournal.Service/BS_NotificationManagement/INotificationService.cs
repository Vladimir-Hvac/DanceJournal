using DanceJournal.Services.BS_NotificationManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Services.BS_NotificationManagement
{
    public interface INotificationService
    {
        event EventHandler OnNotificationReceived;
        Task<List<NotificationDTO>> GetNotReadNotifications(int userId);
        Task<NotificationDTO?> ReadNotification(int notificationId);
        Task<bool> AcceptInvitation(int invitationId, int notificationId, int userId);
        Task<bool> DeclineInvitation(int invitationId, int notificationId, int userId);

        //Методы для отправления приглашения на занятие
        Task<List<LessonDTO>> ProvideLessons(int userId); //
        Task<List<UserDTO>> ProvideRecipients(int eventId); // Приглашаются люди с равным или большим уровнем, который указан в уровне урока
        Task<bool> SentInvitation(int eventId, List<int> recipientsIds);
    }
}
