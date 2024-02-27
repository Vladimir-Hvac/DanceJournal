﻿using DanceJournal.Domain.Models;
using DanceJournal.Services.BS_NotificationManagement;
using DanceJournal.Services.BS_NotificationManagement.Contracts;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class NotificationCard
    {
        [Inject]
        public INotificationService NotificationService { get; set; }

        [Parameter]
        public int NotificationId { get; set; }


        private List<NotificationDTO> _notifications;
        private NotificationDTO _notification;
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
                _notification = new();
            }
            _render = true;
        }
    }
}
