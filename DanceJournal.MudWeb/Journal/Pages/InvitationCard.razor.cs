using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement;
using DanceJournal.Services.BS_NotificationManagement.Contracts;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class InvitationCard
    {
        [Inject]
        public INotificationService NotificationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Parameter]
        public int NotificationId { get; set; }

        private NotificationDTO? _notification;
        private Invitation? _invitation;
        private CurrentAuthUser? _currentAuthUser;
        private Action<SnackbarOptions> _snackbarOptions;

        private bool _render;
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

            _notification = await NotificationService.ReadNotification(NotificationId, _currentAuthUser);
            if (_notification is null)
            {
                //TODO: User informing
                return;
            }

            _invitation = _notification.Invitation;

            _render = true;
        }
        private async void OnAcceptClick()
        {
            if (_currentAuthUser is null || _invitation is null)
            {
                //TODO: inform user or something
                return;
            }
            bool result = await NotificationService.AcceptInvitation(_invitation.Id, NotificationId, _currentAuthUser);
            if (result)
            {
                Snackbar.Add("Приглашение успешно принято", Severity.Success, _snackbarOptions);
                await Task.Delay(1000);
                NavigationManager.NavigateTo("/notifications", true);
            }
            else
            {
                Snackbar.Add("Произошел сбой при отклонении приглашения", Severity.Error, _snackbarOptions);
            }
        }
        private async void OnDeclineClick()
        {
            if (_currentAuthUser is null || _invitation is null)
            {
                //TODO: inform user or something
                return;
            }
            bool result = await NotificationService.DeclineInvitation(_invitation.Id, NotificationId, _currentAuthUser);
            if (result)
            {
                Snackbar.Add("Приглашение успешно отклонено", Severity.Success, _snackbarOptions);
                await Task.Delay(1000);
                NavigationManager.NavigateTo("/notifications", true);
            }
            else
            {
                Snackbar.Add("Произошел сбой при отклонении приглашения", Severity.Error, _snackbarOptions);
            }
        }
    }
}
