using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class LessonTypesComponent
    {
        [Inject]
        public DataMapping _dataMapping { get; set; }

        private List<LessonType>? LessonTypes;
        private string _searchString;
        private bool _isCellEditMode;
        private bool _readOnly;

        private string _name;
        private string _type;
        private int _price;
        private string _selectedType;

        protected override async Task OnInitializedAsync()
        {
            LessonTypes = _dataMapping.LessonTypesDTO;
        }

        private void StartedEditingItem(LessonType lessonType) { }

        private void CanceledEditingItem(LessonType lessonType) { }

        private void CommittedItemChanges(LessonType lessonType)
        {
            lessonType.Type = _selectedType;
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

        private void AddLessonType()
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
    }
}
