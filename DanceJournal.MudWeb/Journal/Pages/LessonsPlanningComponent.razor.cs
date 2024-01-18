using DanceJournal.Service.BS_NotificationManagement;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages;

public partial class LessonsPlanningComponent
{
    [Inject]
    public DanceJournalDbContext DjDbContext { get; set; }

    [Inject]
    public INotificationService NotificationService { get; set; }

    [Inject]
    public ILessonPlanning LessonPlanning { get; set; }
    private List<LessonTypeDto>? LessonTypes;
    private List<LessonDTO>? Lessons;
    private string _searchString;
    private bool _isCellEditMode;
    private bool _readOnly;

    protected override async Task OnInitializedAsync()
    {
        //DjDbContext.Users.Add(new User() { Name = "Peter" });
        //DjDbContext.SaveChanges();
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
