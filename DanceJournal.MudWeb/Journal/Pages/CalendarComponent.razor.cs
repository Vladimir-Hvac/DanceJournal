using Heron.MudCalendar;
using Microsoft.AspNetCore.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class CalendarComponent
    {
        private List<CalendarItem> _events = new List<CalendarItem>();

        public List<Lesson> Lessons { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Lessons = new List<Lesson>();
            Lessons.Add(
                new Lesson()
                {
                    Date = DateTime.Now,
                    LessonType = new LessonType() { Name = "Танго", Price = 1200 },
                    Level = new Level() { Coefficient = 0.5, Title = "F" },
                    Room = new Room() { Name = "Танц зал 1" },
                    Start = new DateTime(2024, 01, 24, 16, 00, 00),
                    Finish = new DateTime(2024, 01, 24, 18, 00, 00),
                }
            );

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
