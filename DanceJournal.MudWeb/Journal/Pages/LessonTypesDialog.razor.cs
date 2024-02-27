using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    public partial class LessonTypesDialog
    {
        private string _name;
        private string _type;
        private int _price;
        private string _selectedType;
        private List<LessonType>? LessonTypes;
        private CancellationToken _cancellationToken;

        [Inject]
        private ILessonPlanning _lessonPlanning { get; set; }

        protected override async Task OnInitializedAsync()
        {
            LessonTypes = _lessonPlanning.GetAllLessonsTypesAsync().Result.ToList();
        }

        private void Submit()
        {
            LessonType lessonType = new LessonType()
            {
                Name = _name,
                Type = _type,
                Price = _price
            };
            LessonTypes?.Add(lessonType);
            _name = string.Empty;
            _type = string.Empty;
            _price = 0;
        }

        private void Cancel() { }
    }
}
