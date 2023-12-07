using DanceJournal.MudWeb.Journal.Models;

namespace DanceJournal.MudWeb.Journal.Pages;

partial class LessonsPlanningComponent
{
    private IEnumerable<ELement>? Elements;

    protected override async Task OnInitializedAsync()
    {
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
