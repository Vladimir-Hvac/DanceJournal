using DanceJournal.Service.BS_NotificationManagement.Contracts;
using DanceJournal.Service.BS_NotificationManagement.Entities;
using DanceJournal.Service.BS_NotificationManagement.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Service.BS_NotificationManagement
{
    public interface INotificationService
    {
        event EventHandler OnNotificationReceived;
        Task<List<NotificationDTO>> GetNotReadNotifications(int userId);
        Task<NotificationDTO?> ReadNotification(int notificationId);
        bool MarkAsRead(int notificationId); // уйдет в ReadNotification
        bool AcceptInvitation(int notificationId);
        bool DeclineInvitation(int notificationId);


        List<EventDTO> ProvideEvents(int userId); //
        List<UserDTO> ProvideRecipients(int eventId); // Приглашаются люди с равным или большим уровнем, который указан в уровне урока
        bool SentInvitation(int eventId, List<int> recipientsIds);
    }

    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public EventHandler OnNotificationReceived => throw new NotImplementedException();

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        event EventHandler INotificationService.OnNotificationReceived
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<NotificationDTO>> GetNotReadNotifications(int userId)
        {
            List<NotificationDTO> result = new();
            try
            {
                List<InvitationNotificationStatus> invitationNotificationStatuses = await _notificationRepository.GetAllInvitationNotificationStatuses();
                invitationNotificationStatuses = invitationNotificationStatuses.Where(x => x.ReceiverId.Equals(userId) && !x.IsRead).ToList();

                result.AddRange(MapNotificationDTOs(invitationNotificationStatuses));
            }
            catch (Exception ex)
            {
                //TODO: Implement logging
            }

            return result;
        }

        public bool AcceptInvitation(int notificationId)
        {
            throw new NotImplementedException();
        }

        public bool DeclineInvitation(int notificationId)
        {
            throw new NotImplementedException();
        }

        public bool MarkAsRead(int notificationId)
        {
            throw new NotImplementedException();
        }

        public List<EventDTO> ProvideEvents(int userId)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> ProvideRecipients(int eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<NotificationDTO?> ReadNotification(int notificationId)
        {
            NotificationDTO? result = null;
            List<InvitationNotificationStatus> invitationNotificationStatuses = await _notificationRepository.GetAllInvitationNotificationStatuses();

            InvitationNotificationStatus? foundInvitationNotificationStatus = invitationNotificationStatuses.FirstOrDefault(x => x.Notification != null && x.Notification.Id.Equals(notificationId));

            if (foundInvitationNotificationStatus != null)
            {
                foundInvitationNotificationStatus.IsRead = true;
                bool updateResult = await _notificationRepository.UpdateInvitationNotificationStatus(foundInvitationNotificationStatus);
                result = MapNotificationDTO(foundInvitationNotificationStatus);
            }

            return result;
        }

        public bool SentInvitation(int eventId, List<int> recipientsIds)
        {
            throw new NotImplementedException();
        }




        private static List<NotificationDTO> MapNotificationDTOs(List<InvitationNotificationStatus> invitationNotificationStatuses)
        {
            List<NotificationDTO> result = new();
            foreach (var notification in invitationNotificationStatuses)
            {
                result.Add(MapNotificationDTO(notification));
            }
            return result;
        }
        private static NotificationDTO MapNotificationDTO(InvitationNotificationStatus invitationNotificationStatus)
        {
            NotificationDTO notificationDTO = new()
            {
                IsRead = invitationNotificationStatus.IsRead,
                Body = invitationNotificationStatus.Notification is null ? string.Empty : invitationNotificationStatus.Notification.Body,
                InvitationDTO = MapInvitationDTO(invitationNotificationStatus.Invitation) 
            };
            return notificationDTO;
        }
        private static InvitationDTO? MapInvitationDTO(Invitation? invitation)
        {
            InvitationDTO? invitationDTO = null;

            if(invitation is not null)
            {
                invitationDTO = new()
                {
                    Id = invitation.Id,
                    IsAccepted = invitation.IsAccepted,
                };
            }

            return invitationDTO;
        }
    }

    class Client
    {
        private INotificationService notificationService;
        public Client()
        {
            notificationService.OnNotificationReceived += DoSmth;
        }

        public async void DoSmth(object sender, EventArgs eventArgs)
        {
            List<NotificationDTO> notif = await notificationService.GetNotReadNotifications(1);
        }
    }
}
