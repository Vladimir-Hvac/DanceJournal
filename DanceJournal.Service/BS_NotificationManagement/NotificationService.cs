using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement.Contracts;
using DanceJournal.Services.BS_NotificationManagement.Gateways;

namespace DanceJournal.Services.BS_NotificationManagement
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository; // выбрать 1 из вариантов

        public EventHandler OnNotificationReceived => throw new NotImplementedException();

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        event EventHandler INotificationService.OnNotificationReceived
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        public async Task<List<Notification>> GetNotReadNotifications(int userId)
        {
            List<Notification> result = new();
            try
            {
                List<InvitationNotificationStatus> invitationNotificationStatuses =
                    await _notificationRepository.GetAllInvitationNotificationStatuses();
                invitationNotificationStatuses = invitationNotificationStatuses
                    .Where(x => x.ReceiverId.Equals(userId) && !x.IsRead)
                    .ToList();

                result.AddRange(MapNotificationDTOs(invitationNotificationStatuses));
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }

            return result;
        }

        public async Task<bool> AcceptInvitation(int invitationId, int notificationId, int userId)
        {
            bool result = false;
            bool isVisit = true;

            Invitation? invitation = await _notificationRepository.GetInvitation(invitationId);
            if (invitation is null)
            {
                //TODO: Logging
                return result;
            }
            List<InvitationNotificationStatus> invitationNotificationStatuses =
                await _notificationRepository.GetAllInvitationNotificationStatuses();
            InvitationNotificationStatus? foundInvitationNotificationStatus =
                invitationNotificationStatuses.FirstOrDefault(
                    x =>
                        x.InvitationId.Equals(invitationId)
                        && x.NotificationId.Equals(notificationId)
                        && x.ReceiverId.Equals(userId)
                );
            if (foundInvitationNotificationStatus is null)
            {
                //TODO: Logging
                return result;
            }

            foundInvitationNotificationStatus.IsAccepted = true;
            result = await _notificationRepository.UpdateInvitationNotificationStatus(
                foundInvitationNotificationStatus
            );
            if (!result)
            {
                //TODO: Logging
                return result;
            }

            int lessonId = invitation.LessonId;
            /*
                bool succeed = LessonPlanningService.SheduleLesson(userId, lessonId, isVisit);
             */
            return result;
        }

        public async Task<bool> DeclineInvitation(int invitationId, int notificationId, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Lesson>> ProvideLessons(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> ProvideRecipients(int eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<Notification?> ReadNotification(int notificationId)
        {
            Notification? result = null;
            List<InvitationNotificationStatus> invitationNotificationStatuses =
                await _notificationRepository.GetAllInvitationNotificationStatuses();

            InvitationNotificationStatus? foundInvitationNotificationStatus =
                invitationNotificationStatuses.FirstOrDefault(
                    x => x.Notification != null && x.Notification.Id.Equals(notificationId)
                );

            if (foundInvitationNotificationStatus != null)
            {
                foundInvitationNotificationStatus.IsRead = true;
                bool updateResult =
                    await _notificationRepository.UpdateInvitationNotificationStatus(
                        foundInvitationNotificationStatus
                    );
                result = MapNotification(foundInvitationNotificationStatus);
            }

            return result;
        }

        public async Task<bool> SentInvitation(int eventId, List<int> recipientsIds)
        {
            throw new NotImplementedException();
        }

        private static List<Notification> MapNotificationDTOs(
            List<InvitationNotificationStatus> invitationNotificationStatuses
        )
        {
            List<Notification> result = new();
            foreach (var notification in invitationNotificationStatuses)
            {
                result.Add(MapNotification(notification));
            }
            return result;
        }

        private static Notification MapNotification(
            InvitationNotificationStatus invitationNotificationStatus
        )
        {
            Notification notification =
                new()
                {
                    Id = invitationNotificationStatus.NotificationId,
                    IsRead = invitationNotificationStatus.IsRead,
                    Body = invitationNotificationStatus.Notification is null
                        ? string.Empty
                        : invitationNotificationStatus.Notification.Body,
                    Invitation = invitationNotificationStatus.Invitation
                };
            return notification;
        }
    }
}
