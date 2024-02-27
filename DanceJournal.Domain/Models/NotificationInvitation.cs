namespace DanceJournal.Domain.Models
{
    public class NotificationInvitation
    {
        public int NotificationId { get; set; }
        public int InvitationId { get; set; }

        public Notification? Notification { get; set; }
        public Invitation? Invitation { get; set; }
    }
}
