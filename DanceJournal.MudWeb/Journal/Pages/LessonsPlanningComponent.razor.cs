using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class LessonsPlanningComponent
    {
        [Inject]
        public DataMapping _dataMapping { get; set; }

        private List<Lesson>? Lessons;
        private string _searchString;
        private bool _isCellEditMode;
        private bool _readOnly;

        protected override async Task OnInitializedAsync()
        {
            Lessons = _dataMapping.LessonsDTO;
            var currentLessonType = _dataMapping.LessonTypesDTO.Where(
                e => e.Name.Equals("Грязные танцы")
            );
            /*foreach (var lesson in Lessons)
            {
                lesson.LessonType = _dataMapping.GetLessonType(lesson.LessonTypeId);
                lesson.Room = _dataMapping.GetRoom(lesson.RoomId);
                lesson.Level = _dataMapping.GetLevel(lesson.LevelId);
            }*/
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
