using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.Service.BS_NotificationManagement;
using DanceJournal.Service.BS_NotificationManagement.Gateways;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class LessonsPlanningComponent
    {
        [Inject]
        public INotificationRepository NotificationRepository { get; set; }

        /// Не должно быть в Preesentation. Только в Services

        [Inject]
        public INotificationService NotificationService { get; set; }

        [Inject]
        public ILessonPlanning LessonPlanning { get; set; }
        private List<Lesson>? Lessons;
        private string _searchString;
        private bool _isCellEditMode;
        private bool _readOnly;

        protected override async Task OnInitializedAsync()
        {
            Lessons = new List<Lesson>();
            Lessons.Add(
                new Lesson()
                {
                    Date = DateTime.Now,
                    LessonType = new LessonType() { Name = "Танго", Price = 1200 },
                    Level = new Level() { Coefficient = 0.5, Title = "F" },
                    Room = new Room() { Name = "Танц зал 1" },
                }
            );
        }

        private void StartedEditingItem(Lesson lessonType) { }

        private void CanceledEditingItem(Lesson lessonType) { }

        private void CommittedItemChanges(Lesson lessonType) { }

        private Func<Lesson, bool> _quickFilter =>
            x =>
            {
                if (string.IsNullOrWhiteSpace(_searchString))
                    return true;

                if (x.LessonType.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                    return true;

                return false;
            };
    }
}
