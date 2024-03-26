using DanceJournal.Domain.Models;
using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.Services.BS_NotificationManagement;
using DanceJournal.Services.BS_NotificationManagement.Contracts;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class NotificationComponent
    {
        [Inject]
        public INotificationService NotificationService { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        [Parameter]
        public int NotificationId { get; set; }

        private List<NotificationDTO> _notifications = new();

        private bool _isReadingMode = false;

        private CurrentAuthUser? _currentAuthUser;

        private NotificationDTO? _selectedNotification;

        private readonly DialogOptions _dialogOptions =
            new() { MaxWidth = MaxWidth.Medium, FullWidth = true };

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
            _selectedNotification = null;
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
            _selectedNotification = null;
            _isReadingMode = false;
            await InvokeAsync(StateHasChanged);
        }
        private async void OnCreateInvitationClick()
        {
            if (_currentAuthUser is null)
            {
                //TODO: inform user or something
                return;
            }

            string title = "Создать приглашение";
            UpsertInvitationVM upsertInvitationVM =
                new() { CurrentAuthUser = _currentAuthUser };

            DialogParameters parameters =
                new() { { nameof(UpsertInvitationVM), upsertInvitationVM } };
            var dialog = await DialogService.ShowAsync<UpsertInvitationDialog>(
                title,
                parameters,
                _dialogOptions
            );
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadNotReadNotifications();
            }
        }
        private async void OnCreateNotificationClick()
        {
            if (_currentAuthUser is null)
            {
                //TODO: inform user or something
                return;
            }
            string title = "Создать уведомление";
            UpsertNotificationVM upsertNotificationVM =
                new() { CurrentAuthUser = _currentAuthUser };
            DialogParameters parameters =
                new() { { nameof(UpsertNotificationVM), upsertNotificationVM } };
            var dialog = await DialogService.ShowAsync<UpsertNotificationDialog>(
                title,
                parameters,
                _dialogOptions
            );

            var result = await dialog.Result;
            if (!result.Canceled)
            {
                await LoadNotReadNotifications();
            }
        }
        private async Task LoadNotReadNotifications()
        {
            if (_currentAuthUser is null)
            {
                return;
            }
            _notifications = await NotificationService.GetNotReadNotifications(_currentAuthUser);
            await InvokeAsync(StateHasChanged);
        }
    }
}
