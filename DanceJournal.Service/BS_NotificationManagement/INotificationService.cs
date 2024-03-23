using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement.Contracts;

namespace DanceJournal.Services.BS_NotificationManagement
{
    public interface INotificationService
    {
        Task<List<NotificationDTO>> GetNotReadNotifications(CurrentAuthUser currentAuthUser);
        Task<List<NotificationDTO>> GetReadNotifications(CurrentAuthUser currentAuthUser);
        Task<NotificationDTO?> ReadNotification(int notificationId, CurrentAuthUser currentAuthUser);
        Task<bool> AcceptInvitation(int invitationId, int notificationId, CurrentAuthUser currentAuthUser);
        Task<bool> DeclineInvitation(int invitationId, int notificationId, CurrentAuthUser currentAuthUser);

        //Методы для отправления приглашения на занятие
        Task<List<Lesson>> ProvideLessons(CurrentAuthUser currentAuthUser); //
        Task<List<User>> ProvideRecipientsByLesson(int lessonId); // Приглашаются люди с равным или большим уровнем, который указан в уровне урока
        Task<List<User>> ProvideRecipients();
        Task<bool> SendInvitation(InvitationCreationDTO invitationCreationDTO, CurrentAuthUser currentAuthUser);
        Task<bool> SendNotification(NotificationCreationDTO notificationCreationDTO, CurrentAuthUser currentAuthUser);
    }
}
