using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace DanceJournal.MudWeb.Journal.Pages;

partial class LessonsPlanningComponent
{
    [Inject]
    public DanceJournalDbContext DjDbContext { get; set; }
    private IEnumerable<LessonTypeDto>? LessonTypes;
    private string _searchString;

    protected override async Task OnInitializedAsync() { }
}
