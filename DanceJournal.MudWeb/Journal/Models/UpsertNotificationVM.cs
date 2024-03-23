using DanceJournal.Domain.Models;

namespace DanceJournal.MudWeb.Journal.Models
{
    public class UpsertNotificationVM
    {
        public CurrentAuthUser? CurrentAuthUser { get; set; }
        public List<User> Recipients { get; set; } = new();
        public string NotificationBody { get; set; } = string.Empty;
        public List<User> SelectedUsers { get; set; } = new();
        public User SelectedUser { get; set; }
    }
}
