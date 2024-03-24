using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement.Contracts;
using DanceJournal.Services.BS_NotificationManagement.Gateways;
using DanceJournal.Services.BS_NotificationManagement.Mapping;

namespace DanceJournal.Services.BS_NotificationManagement
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<List<NotificationDTO>> GetNotReadNotifications(CurrentAuthUser currentAuthUser)
        {
            List<NotificationDTO> result = new();
            try
            {
                User? user = await _notificationRepository.GetUser(currentAuthUser.UserEmail);
                if (user is null)
                {
                    //TODO: Implement logging
                    return result;
                }


                List<(NotificationStatus, InvitationStatus?)> notificInvStatuses = await _notificationRepository.GetNotReadNotificationStatusesByReceiver(user.Id);

                result.AddRange(NotificationMapper.MapNotificationDTOs(notificInvStatuses));
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }

            return result;
        }

        public async Task<List<NotificationDTO>> GetReadNotifications(CurrentAuthUser currentAuthUser)
        {
            List<NotificationDTO> result = new();
            try
            {
                User? user = await _notificationRepository.GetUser(currentAuthUser.UserEmail);
                if (user is null)
                {
                    //TODO: Implement logging
                    return result;
                }


                List<(NotificationStatus, InvitationStatus?)> notificInvStatuses = await _notificationRepository.GetReadNotificationStatusesByReceiver(user.Id);

                result.AddRange(NotificationMapper.MapNotificationDTOs(notificInvStatuses));
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }

            return result;
        }

        public async Task<NotificationDTO?> ReadNotification(int notificationId, CurrentAuthUser currentAuthUser)
        {
            NotificationDTO? result = null;
            try
            {
                User? user = await _notificationRepository.GetUser(currentAuthUser.UserEmail);
                if (user is null)
                {
                    //TODO: Implement logging
                    return result;
                }

                var notInv = await _notificationRepository.GetNotificationStatus(notificationId, user.Id);

                if (notInv is null)
                {
                    //TODO: Implement logging
                    return result;
                }

                NotificationStatus notificationStatus = notInv.Value.Item1;

                //Temporary
                //notificationStatus.IsRead = true;
                //bool updateResult = await _notificationRepository.UpdateNotificationStatus(notificationStatus);

                bool updateResult = true;
                if (!updateResult)
                {
                    //TODO: Implement logging
                    return result;
                }

                result = NotificationMapper.MapNotificationDTO(notInv.Value.Item1, notInv.Value.Item2);
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
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

                result = await HandleInvitation(invitationId, user.Id, true);
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
                result = await HandleInvitation(invitationId, user.Id, false);
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

                List<(InvitationStatus, int)> statusesToAdd = new();
                foreach (var recipientId in recipientsIds)
                {
                    InvitationStatus invitationStatus = new()
                    {
                        InvitationId = invitationId,
                        ReceiverId = recipientId,
                        IsAccepted = false
                    };
                    statusesToAdd.Add((invitationStatus, notificationId));
                }

                result = await _notificationRepository.AddInvitationStatuses(statusesToAdd);

                return result;
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }
            return result;
        }

        private async Task<bool> HandleInvitation(int invitationId, int userId, bool goingToVisit)
        {
            bool result = false;
            bool isVisit = goingToVisit;

            Invitation? invitation = await _notificationRepository.GetInvitation(invitationId);
            if (invitation is null)
            {
                //TODO: Logging
                return result;
            }
            InvitationStatus? foundInvitationStatus = await _notificationRepository.GetInvitationStatus(invitationId, userId);
            if (foundInvitationStatus is null)
            {
                //TODO: Logging
                return result;
            }

            if (foundInvitationStatus.Invitation != null
                && !foundInvitationStatus.Invitation.IsSatisfied)
            {
                if (isVisit)
                {
                    foundInvitationStatus.IsAccepted = true;
                    foundInvitationStatus.IsDeclined = false;
                }
                else
                {
                    foundInvitationStatus.IsAccepted = false;
                    foundInvitationStatus.IsDeclined = true;
                }

                result = await _notificationRepository.UpdateInvitationStatus(
                    foundInvitationStatus
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
                List<InvitationStatus> invitationStatuses =
                    await _notificationRepository.GetInvitationStatusesByInvitaionId(invitationId);
                result = invitationStatuses
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
