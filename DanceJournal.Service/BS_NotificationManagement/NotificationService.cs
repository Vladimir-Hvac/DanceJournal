using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement.Gateways;

namespace DanceJournal.Services.BS_NotificationManagement
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<List<Notification>> GetNotReadNotifications(CurrentAuthUser currentAuthUser)
        {
            List<Notification> result = new();
            try
            {
                User? user = await _notificationRepository.GetUser(currentAuthUser.UserEmail);
                if (user is null)
                {
                    //TODO: Implement logging
                    return result;
                }

                List<InvitationNotificationStatus> invitationNotificationStatuses =
                    await _notificationRepository.GetAllInvitationNotificationStatuses();
                invitationNotificationStatuses = invitationNotificationStatuses
                    .Where(x => x.ReceiverId.Equals(user.Id) && !x.IsRead)
                    .Where(x => x.Invitation is null || (x.Invitation != null && x.Invitation.IsSatisfied != true))
                    .ToList();

                result.AddRange(MapNotificationDTOs(invitationNotificationStatuses));
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }

            return result;
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

        public async Task<bool> AcceptInvitation(int invitationId, int notificationId, CurrentAuthUser currentAuthUser)
        {
            bool result = false;
            try
            {
                User? user = await _notificationRepository.GetUser(currentAuthUser.UserEmail);
                if (user is null)
                {
                    //TODO: Implement logging
                    return result;
                }

                result = await HandleInvitation(invitationId, notificationId, user.Id, true);
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }
            return result;
        }

        public async Task<bool> DeclineInvitation(int invitationId, int notificationId, CurrentAuthUser currentAuthUser)
        {
            bool result = false;
            try
            {
                User? user = await _notificationRepository.GetUser(currentAuthUser.UserEmail);
                if (user is null)
                {
                    //TODO: Implement logging
                    return result;
                }
                result = await HandleInvitation(invitationId, notificationId, user.Id, false);
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }
            return result;
        }

        public async Task<List<Lesson>> ProvideLessons(CurrentAuthUser currentAuthUser)
        {
            List<Lesson> result = new();
            try
            {
                User? user = await _notificationRepository.GetUser(currentAuthUser.UserEmail);
                if (user is null)
                {
                    //TODO: Implement logging
                    return result;
                }
                List<Lesson> allLessons = await _notificationRepository.GetAllLessons();

                if (user.Role.Id.Equals(2))
                {
                    result = allLessons.Where(x => x.UserId.Equals(user.Id)).ToList();
                }
                else if (!user.Role.Id.Equals(1))
                {
                    result = allLessons;
                }
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }
            return result;

        }

        public async Task<List<User>> ProvideRecipients(int lessonId)
        {
            List<User> result = new();
            try
            {
                Lesson? lesson = await _notificationRepository.GetLesson(lessonId);
                if (lesson is null)
                {
                    //TODO: Implement logging
                    return result;
                }
                Level? level = lesson.Level;
                if (level is null)
                {
                    //TODO: Implement logging
                    return result;
                }

                List<User> users = await _notificationRepository.GetAllUsers();
                result = users.Where(x => x.Level.Id.Equals(level.Id)).ToList();
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }
            return result;
        }

        public async Task<bool> SendInvitation(string body, int lessonId, List<int> recipientsIds, CurrentAuthUser currentAuthUser)
        {
            bool result = false;
            try
            {
                User? user = await _notificationRepository.GetUser(currentAuthUser.UserEmail);
                if (user is null)
                {
                    //TODO: Implement logging
                    return result;
                }
                Lesson? lesson = await _notificationRepository.GetLesson(lessonId);
                if (lesson is null)
                {
                    //TODO: Implement logging
                    return result;
                }

                Invitation invitation = new()
                {
                    CreatorId = user.Id,
                    LessonId = lessonId,
                    IsSatisfied = false,
                };

                int invitationId = await _notificationRepository.AddInvitation(invitation);
                if (invitationId == -1)
                {
                    //TODO: Implement logging
                    return result;
                }

                Notification notification = new()
                {
                    Body = body,
                    CreatorId = user.Id
                };
                int notificationId = await _notificationRepository.AddNotification(notification);
                if (notificationId == -1)
                {
                    //TODO: Implement logging
                    return result;
                }

                List<InvitationNotificationStatus> statusesToAdd = new();
                foreach (var recipientId in recipientsIds)
                {
                    InvitationNotificationStatus invitationNotificationStatus = new()
                    {
                        InvitationId = invitationId,
                        NotificationId = notificationId,
                        ReceiverId = recipientId,
                        IsAccepted = false,
                        IsRead = false
                    };
                    statusesToAdd.Add(invitationNotificationStatus);
                }

                result = await _notificationRepository.AddInvitationNotificationStatuses(statusesToAdd);

                return result;
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }
            return result;
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
                    Creator = invitationNotificationStatus.User is null
                        ? null
                        : invitationNotificationStatus.User,
                    Body = invitationNotificationStatus.Notification is null
                        ? string.Empty
                        : invitationNotificationStatus.Notification.Body,
                    Invitation = invitationNotificationStatus.Invitation is null
                        ? null
                        : invitationNotificationStatus.Invitation

                };
            return notification;
        }
        private async Task<bool> HandleInvitation(int invitationId, int notificationId, int userId, bool goingToVisit)
        {
            bool result = false;
            bool isVisit = goingToVisit;

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

            if (foundInvitationNotificationStatus.Invitation != null
                && !foundInvitationNotificationStatus.Invitation.IsSatisfied)
            {
                foundInvitationNotificationStatus.IsAccepted = isVisit;
                result = await _notificationRepository.UpdateInvitationNotificationStatus(
                    foundInvitationNotificationStatus
                );
                if (!result)
                {
                    //TODO: Logging
                    return result;
                }

                if (await IsInvitationSatisfied(invitationId))
                {
                    Invitation? inv = await _notificationRepository.GetInvitation(invitationId);
                    if (inv is null)
                    {
                        //TODO: Logging
                        return result;
                    }
                    inv.IsSatisfied = true;
                    result = await _notificationRepository.UpdateInvitation(inv);
                    if (!result)
                    {
                        //TODO: Logging
                        return result;
                    }
                }

                if (isVisit)
                {
                    int lessonId = invitation.LessonId;
                    /*
                        bool succeed = LessonPlanningService.SheduleLesson(userId, lessonId, isVisit);
                     */
                }
            }

            return result;
        }
        private async Task<bool> IsInvitationSatisfied(int invitationId)
        {
            bool result = false;
            try
            {
                List<InvitationNotificationStatus> invitationNotificationStatuses =
                    await _notificationRepository.GetAllInvitationNotificationStatuses();
                result = invitationNotificationStatuses
                    .Where(x => x.InvitationId.Equals(invitationId))
                    .All(x => x.IsAccepted);
            }
            catch (Exception ex)
            {
                //TODO: Logging
            }
            return result;
        }
    }
}
