using DanceJournal.Domain.Models;

namespace DanceJournal.MudWeb.Journal.Models
{
    public class UpsertNotificationVM
    {
        public CurrentAuthUser? CurrentAuthUser { get; set; }
        public List<User> Recipients { get; set; } = new();
        public string NotificationBody { get; set; } = string.Empty;
        public IEnumerable<User> SelectedUsers { get; set; } = Enumerable.Empty<User>();
        public User SelectedUser { get; set; }
    }
}
