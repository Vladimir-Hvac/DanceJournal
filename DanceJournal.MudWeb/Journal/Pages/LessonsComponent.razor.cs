using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Pages
{
    public partial class LessonsComponent
    {

        [Inject]
        public ILessonPlanning LessonPlanning { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        private List<Lesson>? Lessons;
        private string _searchString;

        protected override async Task OnInitializedAsync()
        {
            var lessons = await LessonPlanning.GetAllLessonsAsync();
            Lessons = lessons.ToList();
        }

        private bool FilterFunc1(Lesson element) => FilterFunc(element, _searchString);

        private bool FilterFunc(Lesson element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.LessonType.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LessonType.Price.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LessonType.Type.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        private async Task UpdateAsync(Lesson Lesson)
        {
            var parameters = new DialogParameters<LessonsDialog>()
            {
                {x=>x.Lesson,Lesson }
            };
            var options = new DialogOptions { CloseOnEscapeKey = true };
            string title = Lesson.Id ==0 ? "Новый тип" : "Редактировать";
            var dialog = DialogService.Show<LessonsDialog>(title, parameters, options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                Lesson = (Lesson)result.Data;
                var oldLesson = Lessons.FirstOrDefault(x => x.Id.Equals(Lesson.Id));
                if (oldLesson is null)
                {
                    Lessons.Add(Lesson);
                    LessonPlanning.CreateLessonAsync(Lesson);
                }
                else
                {
                    Lessons.Remove(oldLesson);
                    Lessons.Add(Lesson);
                    LessonPlanning.UpdateLessonAsync(Lesson);
                }
            }
        }
        private async Task CopyAsync(Lesson Lesson)
        {
            Lesson.Id = default;
            Lessons?.Add(Lesson);
            await LessonPlanning.UpdateLessonAsync(Lesson);
        }
        private async Task RemoveAsync(Lesson Lesson)
        {
            Lessons?.Remove(Lesson);
            await LessonPlanning.DeleteLesson(Lesson.Id);
        }
    }
}
