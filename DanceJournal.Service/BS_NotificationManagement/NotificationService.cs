﻿using DanceJournal.Contracts.MessageContracts;
using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement.Contracts;
using DanceJournal.Services.BS_NotificationManagement.Gateways;
using DanceJournal.Services.BS_NotificationManagement.Mapping;

namespace DanceJournal.Services.BS_NotificationManagement
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ILessonPlanning _lessonPlanning;
        private readonly IBrokerService _brokerService;

        public NotificationService(INotificationRepository notificationRepository, ILessonPlanning lessonPlanning, IBrokerService brokerService)
        {
            _notificationRepository = notificationRepository;
            _lessonPlanning = lessonPlanning;
            _brokerService = brokerService;
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

                notificationStatus.IsRead = true;
                bool updateResult = await _notificationRepository.UpdateNotificationStatus(notificationStatus);

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

        public async Task<List<User>> ProvideRecipientsByLesson(int lessonId)
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

        public async Task<bool> SendInvitation(InvitationCreationDTO invitationCreationDTO, CurrentAuthUser currentAuthUser)
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
                Lesson? lesson = await _notificationRepository.GetLesson(invitationCreationDTO.LessonId);
                if (lesson is null)
                {
                    //TODO: Implement logging
                    return result;
                }

                Invitation invitation = new()
                {
                    CreatorId = user.Id,
                    LessonId = invitationCreationDTO.LessonId,
                    SatisfactionLimit = invitationCreationDTO.UserLimit,
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
                    Body = invitationCreationDTO.InvitationBody,
                    CreatorId = user.Id
                };
                int notificationId = await _notificationRepository.AddNotification(notification);
                if (notificationId == -1)
                {
                    //TODO: Implement logging
                    return result;
                }

                List<NotificationStatus> notificationStatuses = new();
                foreach (var receipient in invitationCreationDTO.RecipientIds)
                {
                    NotificationStatus notificationStatus = new()
                    {
                        NotificationId = notificationId,
                        ReceiverId = receipient
                    };
                    notificationStatuses.Add(notificationStatus);
                }
                result = await _notificationRepository.AddNotificationStatuses(notificationStatuses);

                if (!result)
                {
                    //TODO: Implement logging
                    return result;
                }

                List<(InvitationStatus, int)> statusesToAdd = new();
                foreach (var recipientId in invitationCreationDTO.RecipientIds)
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

                    LessonUser lessonUser = new()
                    {
                        LessonId = lessonId,
                        UserId = userId,
                        IsVisit = true
                    };

                    await _lessonPlanning.CreateLessonUserAsync(lessonUser);
                    if (lessonUser.Id == 0)
                    {
                        //TODO: Logging
                        return false;
                    }
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
                Invitation? invitation = invitationStatuses.Select(x => x.Invitation).FirstOrDefault();
                if (invitation != null)
                {
                    int userLimits = invitation.SatisfactionLimit;
                    int acceptedInvitations = invitationStatuses
                        .Where(x => x.IsAccepted)
                        .Count();
                    if (acceptedInvitations >= userLimits)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Logging
            }
            return result;
        }
        public async Task<List<User>> ProvideRecipients()
        {
            List<User> users = new();
            try
            {
                users = await _notificationRepository.GetAllUsers();
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }
            return users;
        }

        public async Task<bool> SendNotification(NotificationCreationDTO notificationCreationDTO, CurrentAuthUser currentAuthUser)
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
                Notification notification = new()
                {
                    Body = notificationCreationDTO.NotificationBody,
                    CreatorId = user.Id
                };
                int notificationId = await _notificationRepository.AddNotification(notification);
                if (notificationId == -1)
                {
                    //TODO: Implement logging
                    return result;
                }

                List<NotificationStatus> notificationStatuses = new();
                foreach (var receipient in notificationCreationDTO.RecipientIds)
                {
                    NotificationStatus notificationStatus = new()
                    {
                        NotificationId = notificationId,
                        ReceiverId = receipient
                    };
                    notificationStatuses.Add(notificationStatus);
                }

                result = await _notificationRepository.AddNotificationStatuses(notificationStatuses);
                if (result)
                {
                    _brokerService.PublishNotificationMessage(BuildMessage(user, notificationCreationDTO));
                }

            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }

            return result;
        }

        private NotificationMessageDTO BuildMessage(User sender, NotificationCreationDTO notificationCreationDTO)
        {
            string recievers = string.Empty;
            int i = 0;
            foreach (var receipient in notificationCreationDTO.RecipientIds)
            {
                i++;
                recievers += receipient.ToString();
                if (notificationCreationDTO.RecipientIds.Count > i)
                {
                    recievers += ",";
                }
            }
            return new NotificationMessageDTO()
            { Message = $"User: Id{sender.Id} sent the notification to Users: Ids {recievers}.\nMessage: {notificationCreationDTO.NotificationBody}" };
        }
    }
}
