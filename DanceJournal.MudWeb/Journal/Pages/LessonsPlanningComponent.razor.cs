using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace DanceJournal.MudWeb.Journal.Pages;

partial class LessonsPlanningComponent
{
    [Inject]
    public DanceJournalDbContext DjDbContext { get; set; }
    private IEnumerable<ELement>? Elements;

    protected override async Task OnInitializedAsync()
    {
        //DjDbContext.Users.Add(new User() { Name = "Peter" });
        //DjDbContext.SaveChanges();
        Elements = new List<ELement>()
        {
            new ELement()
            {
                Number = 1,
                Molar = "1587.7",
                Name = "Name",
                Position = "115",
                Sign = "H"
            }
        };
    }
}
