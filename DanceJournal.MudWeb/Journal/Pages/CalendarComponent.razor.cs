using Heron.MudCalendar;
using Microsoft.AspNetCore.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class CalendarComponent
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        private List<Lesson>? Lessons;

        private List<CalendarItem> _events =
            new()
            {
                new CalendarItem
                {
                    Start = DateTime.Today.AddHours(10),
                    End = DateTime.Today.AddHours(11),
                    Text = "Танго"
                },
            };

        private void OnClick() { }
    }
}
