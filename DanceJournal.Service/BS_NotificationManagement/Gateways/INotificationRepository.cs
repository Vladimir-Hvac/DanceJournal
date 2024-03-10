using DanceJournal.Domain.Models;

namespace DanceJournal.Services.BS_NotificationManagement.Gateways
{
    public interface INotificationRepository
    {
        Task<List<(NotificationStatus, InvitationStatus?)>> GetNotReadNotificationStatusesByReceiver(int receiverId);
        Task<List<(NotificationStatus, InvitationStatus?)>> GetReadNotificationStatusesByReceiver(int receiverId);
        Task<(NotificationStatus, InvitationStatus?)?> GetNotificationStatus(int notificationId, int receiverId);

        Task<bool> UpdateNotificationStatus(
            NotificationStatus notificationStatus
        );
        Task<bool> UpdateInvitationStatus(
            InvitationStatus invitationStatus
        );

        Task<List<InvitationStatus>> GetInvitationStatusesByInvitaionId(int invitationId);
        Task<InvitationStatus?> GetInvitationStatus(int invitationId, int receiverId);

        Task<bool> AddInvitationStatuses(List<(InvitationStatus, int notificationId)> invitationStatuses);



        Task<List<Lesson>> GetAllLessons();
        Task<Lesson?> GetLesson(int lessonId);


        Task<int> AddInvitation(Invitation invitation);
        Task<Invitation?> GetInvitation(int invitationId);
        Task<bool> UpdateInvitation(Invitation invitation);

        Task<List<User>> GetAllUsers();
        Task<User?> GetUser(string userEmail);

        Task<int> AddNotification(Notification notification);
    }
}
