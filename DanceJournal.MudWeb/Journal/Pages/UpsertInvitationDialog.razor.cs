using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.Services.BS_NotificationManagement;
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
            UpsertInvitationVM.Lessons = new();

            if (UpsertInvitationVM.SelectedLesson != null)
            {
                List<User> recipients = await NotificationService.ProvideRecipients(UpsertInvitationVM.SelectedLesson.Id);
                UpsertInvitationVM.Recipients = recipients;
            }
        }
        private async Task Submit()
        {
            bool succeed = true;
            //Logic of submitting
            MudDialog.Close(DialogResult.Ok(succeed));
        }

        void Cancel()
        {
            //Logic of cancellation
            MudDialog.Cancel();
        }
    }
}
