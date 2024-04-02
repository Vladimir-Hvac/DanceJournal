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
        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Parameter]
        public int NotificationId { get; set; }

        private List<NotificationDTO> _notifications = new();

        private bool _isReadingMode = false;

        private CurrentAuthUser? _currentAuthUser;

        private NotificationDTO? _selectedNotification;

        private readonly DialogOptions _dialogOptions =
            new() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        private Action<SnackbarOptions> _snackbarOptions;

        private bool _render;

        private string _title = "Новые";

        private int _tabId = 0;

        protected override async Task OnInitializedAsync()
        {
            _snackbarOptions = options =>
            {
                options.SnackbarVariant = Variant.Filled;
                options.ShowCloseIcon = true;
                options.VisibleStateDuration = 5000; // 5 seconds
            };
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
            _title = "Новые";
            _tabId = 0;
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
            _title = "Архив";
            _tabId = 1;
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
                Snackbar.Add("Приглашение успешно создано", Severity.Success, _snackbarOptions);
                await LoadNotReadNotifications();
            }
            else
            {
                Snackbar.Add("Произошел сбой при создании приглашения", Severity.Error, _snackbarOptions);
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
                Snackbar.Add("Уведомление успешно создано", Severity.Success, _snackbarOptions);
                await LoadNotReadNotifications();
            }
            else
            {
                Snackbar.Add("Произошел сбой при создании уведомления", Severity.Error, _snackbarOptions);
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

        private async void OnUpdateClick()
        {
            if (_tabId == 0)
            {
                _notifications = await NotificationService.GetNotReadNotifications(_currentAuthUser);
            }
            else
            {
                _notifications = await NotificationService.GetReadNotifications(_currentAuthUser);
            }
        }
    }
}
