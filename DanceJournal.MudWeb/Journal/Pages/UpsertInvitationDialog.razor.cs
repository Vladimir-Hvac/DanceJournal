using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.Services.BS_NotificationManagement;
using DanceJournal.Services.BS_NotificationManagement.Contracts;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class UpsertInvitationDialog
    {
        [Inject]
        public INotificationService NotificationService { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public UpsertInvitationVM UpsertInvitationVM { get; set; } = new();
        private bool _render;

        protected override async Task OnInitializedAsync()
        {
            UpsertInvitationVM.OnSelectedLessonChanged += OnLessonSelected;
            _render = true;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                List<Lesson> lessons = await NotificationService.ProvideLessons(UpsertInvitationVM.CurrentAuthUser);
                UpsertInvitationVM.Lessons.AddRange(lessons);
            }
        }

        private async void OnLessonSelected(object? sender, EventArgs e)
        {
            if (UpsertInvitationVM.SelectedLesson != null)
            {
                List<User> recipients = await NotificationService.ProvideRecipients(UpsertInvitationVM.SelectedLesson.Id);
                UpsertInvitationVM.Recipients = recipients;
            }
        }
        private async Task Submit()
        {
            bool succeed = true;

            InvitationCreationDTO invitation = new()
            {
                InvitationBody = UpsertInvitationVM.InvitationBody,
                RecipientIds = UpsertInvitationVM.Recipients.Select(x => x.Id).ToList(),
                UserLimit = UpsertInvitationVM.UserLimit
            };

            if (UpsertInvitationVM.SelectedLesson is null || UpsertInvitationVM.CurrentAuthUser is null)
            {
                //User informing
                return;
            }
            invitation.LessonId = UpsertInvitationVM.SelectedLesson.Id;

            succeed = await NotificationService.SendInvitation(invitation, UpsertInvitationVM.CurrentAuthUser);

            MudDialog.Close(DialogResult.Ok(succeed));
        }

        void Cancel()
        {
            //Logic of cancellation
            MudDialog.Cancel();
        }

        private readonly Func<Lesson, string> LessonToString =
            x =>
            {
                if (x is null)
                {
                    return string.Empty;
                }
                return $"Начало: {x.Start} Тип: {x.LessonType.Name} Тренер: {x.User.Surname} {x.User.FirstName}";
            };
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
