using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class LessonsPlanningComponent
    {
        [Inject]
        public DataMapping _dataMapping { get; set; }

        private List<LessonType>? LessonTypes;
        private List<Lesson>? Lessons;
        private string _searchString;
        private bool _isCellEditMode;
        private bool _readOnly;

        protected override async Task OnInitializedAsync()
        {
            Lessons = _dataMapping.LessonsDTO;
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
