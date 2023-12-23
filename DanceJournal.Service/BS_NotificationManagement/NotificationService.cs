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
        NotificationDTO ReadNotification(int notificationId);
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
            List<InvitationNotificationStatus> invitationNotificationStatuses = await _notificationRepository.GetAllInvitationNotificationStatuses();
            invitationNotificationStatuses = invitationNotificationStatuses.Where(x => x.ReceiverId.Equals(userId) && !x.IsRead).ToList();

            result.AddRange(MapNotificationDTOs(invitationNotificationStatuses));

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

        public NotificationDTO ReadNotification(int notificationId)
        {
            throw new NotImplementedException();
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
                Body = invitationNotificationStatus.Notification.Body,
                IsAccepted = invitationNotificationStatus.IsAccepted,
            };
            return notificationDTO;
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
