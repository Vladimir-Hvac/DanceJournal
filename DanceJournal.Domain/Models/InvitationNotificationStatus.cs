namespace DanceJournal.Domain.Models
{
    public class InvitationNotificationStatus
    {
        public int Id { get; set; }
        public int InvitationId { get; set; }
        public int NotificationId { get; set; }
        public int ReceiverId { get; set; }
        public bool IsRead { get; set; }
        public bool IsAccepted { get; set; }

        public Notification? Notification { get; set; }
        public Invitation? Invitation { get; set; }
        public User? User { get; set; }
    }
}
