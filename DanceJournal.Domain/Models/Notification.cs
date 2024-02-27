namespace DanceJournal.Domain.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Body { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; } = new();

        public User? Creator { get; set; }
    }
}
