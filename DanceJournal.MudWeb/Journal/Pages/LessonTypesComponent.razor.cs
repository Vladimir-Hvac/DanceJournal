using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

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

        private IEnumerable<LessonType>? LessonTypes;
        private string _searchString;
        private bool _isCellEditMode;
        private bool _readOnly;

        protected override async Task OnInitializedAsync()
        {
            LessonTypes = await LessonPlanning.GetAllLessonsTypesAsync();
        }

        private Func<LessonType, bool> _quickFilter =>
            x =>
            {
                if (string.IsNullOrWhiteSpace(_searchString))
                    return true;

                if (x.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                    return true;

                //if (x.Type.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                //    return true;

                if ($"{x.Price}".Contains(_searchString))
                    return true;

                return false;
            };

        //private void UpdateLessonTypes(LessonType lessonType)
        //{
        //    var options = new DialogOptions { CloseOnEscapeKey = true };
        //    DialogService.Show<LessonTypesDialog>("Simple Dialog", options);
        //}
    }
}
