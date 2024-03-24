namespace DanceJournal.Services.BS_NotificationManagement.Contracts
{
    public class InvitationCreationDTO
    {
        public int UserLimit { get; set; }
        public string InvitationBody { get; set; } = string.Empty;
        public int LessonId { get; set; }
        public List<int> RecipientIds { get; set; } = new();
    }
}
