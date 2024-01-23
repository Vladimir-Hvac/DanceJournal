namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class LessonTypesComponent
    {
        private List<LessonTypeDto>? LessonTypes;
        private string _searchString;
        private bool _isCellEditMode;
        private bool _readOnly;

        protected override async Task OnInitializedAsync()
        {
            LessonTypes = new List<LessonTypeDto>();
            LessonTypes.Add(
                new LessonTypeDto()
                {
                    Name = "name",
                    Type = "type",
                    Price = 1200
                }
            );
            LessonTypes.Add(
                new LessonTypeDto()
                {
                    Name = "Gena",
                    Type = "type",
                    Price = 1200
                }
            );
        }

        private void StartedEditingItem(LessonTypeDto lessonType) { }

        private void CanceledEditingItem(LessonTypeDto lessonType) { }

        private void CommittedItemChanges(LessonTypeDto lessonType) { }

        private Func<LessonTypeDto, bool> _quickFilter =>
            x =>
            {
                if (string.IsNullOrWhiteSpace(_searchString))
                    return true;

                if (x.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                    return true;

                if (x.Type.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                    return true;

                if ($"{x.Price}".Contains(_searchString))
                    return true;

                return false;
            };
    }
}
