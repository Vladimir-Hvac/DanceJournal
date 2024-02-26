using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class LessonsPlanningComponent
    {
        [Inject]
        public DataMapping _dataMapping { get; set; }

        [Inject]
        public ILessonPlanning _lessonPlanning { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private IEnumerable<Lesson>? Lessons;
        private List<LessonType>? LessonTypes;

        private string _searchString;
        private bool _isCellEditMode;
        private bool _readOnly;
        private LessonType _selectedLessonsType;

        protected override async Task OnInitializedAsync()
        {
            Lessons = await _lessonPlanning.GetAllLessonsAsync();
            //Lessons = _dataMapping.LessonsDTO;
            LessonTypes = _dataMapping.LessonTypesDTO;

            var currentLessonType = _dataMapping.LessonTypesDTO.Where(
                e => e.Name.Equals("Грязные танцы")
            );
        }

        private void StartedEditingItem(Lesson lesson) { }

        private void CanceledEditingItem(Lesson lesson) { }

        private void CommittedItemChanges(Lesson lesson)
        {
            lesson.LessonType = _selectedLessonsType;
            _lessonPlanning.UpdateLessonAsync(lesson);
            NavigationManager.NavigateTo("/lessons", true);
        }

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
