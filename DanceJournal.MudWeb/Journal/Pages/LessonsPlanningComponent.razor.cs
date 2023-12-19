using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace DanceJournal.MudWeb.Journal.Pages;

partial class LessonsPlanningComponent
{
    [Inject]
    public DanceJournalDbContext DjDbContext { get; set; }
    private IEnumerable<Lesson>? Lessons;

    protected override async Task OnInitializedAsync()
    {
        //DjDbContext.Users.Add(new User() { Name = "Peter" });
        //DjDbContext.SaveChanges();
        Lessons = new List<Lesson>()
        {
            new Lesson
            {
                  
            }
        };
        
    }
}
