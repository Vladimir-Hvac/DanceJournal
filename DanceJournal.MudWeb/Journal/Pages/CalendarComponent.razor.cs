using DanceJournal.MudWeb.Journal.Models;
using Heron.MudCalendar;
using Microsoft.AspNetCore.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class CalendarComponent
    {
        private List<CalendarItem> _events = new List<CalendarItem>();

        [Inject]
        public DataMapping _dataMapping { get; set; }
        public List<Lesson> Lessons { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Lessons = _dataMapping.LessonsDTO;

            foreach (var lesson in Lessons)
            {
                CalendarItem calendarItem = new CalendarItem()
                {
                    Start = lesson.Start,
                    End = lesson.Finish,
                    Text = lesson.LessonType.Name
                };
                _events.Add(calendarItem);
            }
        }

        private void OnClick() { }
    }
}
