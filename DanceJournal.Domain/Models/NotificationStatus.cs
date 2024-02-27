namespace DanceJournal.Domain.Models
{
    public class NotificationStatus
    {
        public int NotificationId { get; set; }
        public int ReceiverId { get; set; }
        public bool IsRead { get; set; }

        public Notification? Notification { get; set; }
        public User? Receiver { get; set; }
    }
}
