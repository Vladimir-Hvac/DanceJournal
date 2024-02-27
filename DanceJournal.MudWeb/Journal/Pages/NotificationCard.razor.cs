using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement;
using DanceJournal.Services.BS_NotificationManagement.Contracts;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class NotificationCard
    {
        [Inject]
        public INotificationService NotificationService { get; set; }
        private List<NotificationDTO> _notifications;
        private bool _render;

        protected override async Task OnInitializedAsync()
        {
            CurrentAuthUser currentAuthUser = new CurrentAuthUser()
            {
                UserName = "",
                UserEmail = "CodeX@test.ru",
            };


            _notifications = await NotificationService.GetNotReadNotifications(currentAuthUser);
            //MultiplyElements();
            _render = true;
        }

        private void MultiplyElements()
        {
            for (int i = 0; i < 6; i++)
            {
                _notifications.Add(_notifications[0]);
            }
        }
    }
}
