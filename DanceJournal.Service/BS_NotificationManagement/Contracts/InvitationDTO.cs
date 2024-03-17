namespace DanceJournal.Services.BS_NotificationManagement.Contracts
{
    public class InvitationDTO
    {
        public int Id { get; set; }
        public bool IsDeclined { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsSatisfied { get; set; }
        public bool IsOutdated { get; set; }
        public Lesson Lesson { get; set; } = new();
    }
}
