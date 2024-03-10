using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement;
using DanceJournal.Services.BS_NotificationManagement.Contracts;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class InvitationCard
    {
        [Inject]
        public INotificationService NotificationService { get; set; }

        [Parameter]
        public int NotificationId { get; set; }

        private NotificationDTO? _notification;
        private Invitation? _invitation;

        private bool _render;
        protected override async Task OnInitializedAsync()
        {
            CurrentAuthUser currentAuthUser = new CurrentAuthUser()
            {
                UserName = "",
                UserEmail = "CodeX@test.ru",
            };


            _notification = await NotificationService.ReadNotification(NotificationId, currentAuthUser);
            if (_notification is null)
            {
                //TODO: User informing
                return;
            }

            _invitation = _notification.Invitation;

            _render = true;
        }
    }
}
