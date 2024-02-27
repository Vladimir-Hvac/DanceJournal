using DanceJournal.Domain.Models;

namespace DanceJournal.Services.BS_NotificationManagement.Contracts
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public int ReceiverId { get; set; }
        public string Body { get; set; } = string.Empty;
        public DateOnly Date { get; set; } = new DateOnly();
        public TimeOnly Time { get; set; } = new TimeOnly();

        public User Creator { get; set; } = new();
        public Invitation? Invitation { get; set; }
    }
}
