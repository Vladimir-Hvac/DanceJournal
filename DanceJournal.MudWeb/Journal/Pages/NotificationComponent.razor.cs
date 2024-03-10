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

        private List<NotificationDTO> _notifications = new();

        private bool _isReadingMode = false;

        private CurrentAuthUser? _currentAuthUser;

        private NotificationDTO? _selectedNotification;

        private bool _render;

        protected override async Task OnInitializedAsync()
        {
            _currentAuthUser = new CurrentAuthUser()
            {
                UserName = "",
                UserEmail = "DevZen@test.ru",
            };
            if (_currentAuthUser is null)
            {
                //TODO: inform user or something
                return;
            }
            _notifications = await NotificationService.GetNotReadNotifications(_currentAuthUser);
            _render = true;
        }
        private void OnNotificationClick(NotificationDTO notification)
        {
            // Handle the click event here
            NotificationId = notification.Id;
            _selectedNotification = notification;
            _isReadingMode = true;
            StateHasChanged();
        }
        private async void OnNewNotificationsClick()
        {
            if (_currentAuthUser is null)
            {
                //TODO: inform user or something
                return;
            }
            _notifications = await NotificationService.GetNotReadNotifications(_currentAuthUser);
            _isReadingMode = false;
            await InvokeAsync(StateHasChanged);
        }
        private async void OnArchivedNotificationsClick()
        {
            if (_currentAuthUser is null)
            {
                //TODO: inform user or something
                return;
            }
            _notifications = await NotificationService.GetReadNotifications(_currentAuthUser);
            _isReadingMode = false;
            await InvokeAsync(StateHasChanged);
        }
    }
}
