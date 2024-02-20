using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class NotificationCard
    {
        [Inject]
        public INotificationService NotificationService { get; set; }



        private List<Notification> _notifications;
        private bool _render;

        protected override async Task OnInitializedAsync()
        {
            CurrentAuthUser currentAuthUser = new CurrentAuthUser()
            {
                UserName = "",
                UserEmail = "test@test.ru",
            };

            _notifications = await NotificationService.GetNotReadNotifications(currentAuthUser);
            _render = true;
        }
    }
}
