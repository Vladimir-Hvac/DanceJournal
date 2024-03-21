using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class LessonTypesComponent
    {
        [Inject]
        public DataMapping _dataMapping { get; set; }

        [Inject]
        public ILessonPlanning LessonPlanning { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        private List<LessonType>? LessonTypes;
        private string _searchString;

        protected override async Task OnInitializedAsync()
        {
            var lessonTypes = await LessonPlanning.GetAllLessonsTypesAsync();
            LessonTypes = lessonTypes.ToList();
        }

        private bool FilterFunc1(LessonType element) => FilterFunc(element, _searchString);

        private bool FilterFunc(LessonType element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Price.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Type.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        private async Task UpdateAsync(LessonType lessonType)
        {
            var parameters = new DialogParameters<LessonTypesDialog>() 
            { 
                {x=>x.LessonType,lessonType }
            };
            var options = new DialogOptions { CloseOnEscapeKey = true };
            string title = lessonType.Name is null ? "Новый тип" : "Редактировать"; 
            var dialog = DialogService.Show<LessonTypesDialog>(title, parameters,options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                lessonType = (LessonType)result.Data;
                var oldLessonType = LessonTypes.FirstOrDefault(x => x.Id.Equals(lessonType.Id));
                if (oldLessonType is null)
                {
                    LessonTypes.Add(lessonType);
                    LessonPlanning.CreateLessonTypeAsync(lessonType);
                }
                else
                {
                    LessonTypes.Remove(oldLessonType);
                    LessonTypes.Add(lessonType);
                    LessonPlanning.UpdateLessonTypeAsync(lessonType);
                }
            }
        }
        private async Task CopyAsync(LessonType lessonType) 
        {
            lessonType.Id=default;
            LessonTypes?.Add(lessonType);
            await LessonPlanning.UpdateLessonTypeAsync(lessonType);
        }
        private async Task RemoveAsync(LessonType lessonType)
        {
            LessonTypes?.Remove(lessonType);
            await LessonPlanning.DeleteLessonType(lessonType.Id);
        }
    }
}
