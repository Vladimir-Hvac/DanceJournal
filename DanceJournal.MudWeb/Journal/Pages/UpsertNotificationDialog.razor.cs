using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.Services.BS_NotificationManagement;
using DanceJournal.Services.BS_NotificationManagement.Contracts;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class UpsertNotificationDialog
    {
        [Inject]
        public INotificationService NotificationService { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public UpsertNotificationVM UpsertNotificationVM { get; set; }

        private bool _render;
        protected override void OnInitialized()
        {
            _render = true;
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                List<User> recipients = await NotificationService.ProvideRecipients();
                UpsertNotificationVM.Recipients = recipients;
            }
        }

        private async Task Submit()
        {
            bool succeed = true;

            NotificationCreationDTO notificationCreationDTO = new()
            {
                NotificationBody = UpsertNotificationVM.NotificationBody,
                RecipientIds = UpsertNotificationVM.SelectedUsers.Select(x => x.Id).ToList()
            };

            if (UpsertNotificationVM.CurrentAuthUser is null)
            {
                //User informing
                return;
            }

            succeed = await NotificationService.SendNotification(notificationCreationDTO, UpsertNotificationVM.CurrentAuthUser);

            MudDialog.Close(DialogResult.Ok(succeed));
        }

        void Cancel()
        {
            //Logic of cancellation
            MudDialog.Cancel();
        }

        private readonly Func<User, string> UserToString =
            x =>
            {
                if (x is null)
                {
                    return string.Empty;
                }
                return $"{x.Surname} {x.FirstName}";
            };
    }
}
