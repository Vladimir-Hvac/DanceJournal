using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class LessonsPlanningComponent
    {
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
