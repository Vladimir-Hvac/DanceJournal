namespace DanceJournal.Services.BS_NotificationManagement.Contracts
{
    public class NotificationCreationDTO
    {
        public List<int> RecipientIds { get; set; } = new();
        public string NotificationBody { get; set; } = string.Empty;
    }
}
