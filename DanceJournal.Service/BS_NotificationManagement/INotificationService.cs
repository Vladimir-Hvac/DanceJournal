using DanceJournal.Domain.Models;

namespace DanceJournal.Services.BS_NotificationManagement
{
    public interface INotificationService
    {
        Task<List<Notification>> GetNotReadNotifications(CurrentAuthUser currentAuthUser);
        Task<Notification?> ReadNotification(int notificationId);
        Task<bool> AcceptInvitation(int invitationId, int notificationId, CurrentAuthUser currentAuthUser);
        Task<bool> DeclineInvitation(int invitationId, int notificationId, CurrentAuthUser currentAuthUser);

        //Методы для отправления приглашения на занятие
        Task<List<Lesson>> ProvideLessons(CurrentAuthUser currentAuthUser); //
        Task<List<User>> ProvideRecipients(int lessonId); // Приглашаются люди с равным или большим уровнем, который указан в уровне урока
        Task<bool> SendInvitation(string body, int lessonId, List<int> recipientsIds, CurrentAuthUser currentAuthUser);
    }
}
