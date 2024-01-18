using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace DanceJournal.MudWeb.Journal.Pages;

{
    [Inject]
    public DanceJournalDbContext DjDbContext { get; set; }

    protected override async Task OnInitializedAsync()
    {
        //DjDbContext.Users.Add(new User() { Name = "Peter" });
        //DjDbContext.SaveChanges();
        {
            {
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
