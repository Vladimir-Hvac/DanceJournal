using DanceJournal.Domain.Models;

namespace DanceJournal.Services.BS_NotificationManagement.Gateways
{
    public interface INotificationRepository
    {
        Task<List<InvitationNotificationStatus>> GetAllInvitationNotificationStatuses();

        Task<List<Lesson>> GetAllLessons();
        Task<Lesson?> GetLesson(int lessonId);

        Task<bool> AddInvitationNotificationStatuses(List<InvitationNotificationStatus> invitationNotificationStatuses);
        Task<bool> UpdateInvitationNotificationStatus(
            InvitationNotificationStatus invitationNotificationStatus
        );

        Task<int> AddInvitation(Invitation invitation);
        Task<Invitation?> GetInvitation(int invitationId);
        Task<bool> UpdateInvitation(Invitation invitation);

        Task<List<User>> GetAllUsers();
        Task<User?> GetUser(string userEmail);

        Task<int> AddNotification(Notification notification);
    }
}
