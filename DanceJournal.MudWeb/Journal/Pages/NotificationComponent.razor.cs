using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement;
using DanceJournal.Services.BS_NotificationManagement.Contracts;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class NotificationComponent
    {
        [Inject]
        public INotificationService NotificationService { get; set; }

        [Parameter]
        public int NotificationId { get; set; }

        private List<NotificationDTO> _notifications;

        private bool isReadingMode = false;

        private bool _render;

        protected override async Task OnInitializedAsync()
        {
            CurrentAuthUser currentAuthUser = new CurrentAuthUser()
            {
                UserName = "",
                UserEmail = "CodeX@test.ru",
            };


            _notifications = await NotificationService.GetNotReadNotifications(currentAuthUser);
            _render = true;
        }
        private void OnNotificationClick(NotificationDTO notification)
        {
            // Handle the click event here
            NotificationId = notification.Id;
            isReadingMode = true;
            StateHasChanged();
        }
    }
}
