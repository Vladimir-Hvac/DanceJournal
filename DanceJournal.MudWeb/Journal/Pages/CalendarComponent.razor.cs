using DanceJournal.MudWeb.Journal.Models;
using Heron.MudCalendar;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class CalendarComponent
    {
        private bool _showEvents;
        private Anchor _anchor;
        private Lesson _selectedLesson;
        private List<CalendarItem> _allEvents = new List<CalendarItem>();
        private List<CalendarItem> _myEvents = new List<CalendarItem>();

        [Inject]
        public DataMapping _dataMapping { get; set; }
        public List<Lesson> Lessons { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Lessons = _dataMapping.LessonsDTO;
            _allEvents = GetEvents(Lessons);
            _myEvents = GetEvents(Lessons.Where(e => e.UserId == 1).ToList());
        }

        private void OnClick(CalendarItem caledarItem)
        {
            int index = _allEvents.IndexOf(caledarItem);
            _selectedLesson = Lessons[index];
            _showEvents = !_showEvents;
            _anchor = Anchor.End;
        }

        private List<CalendarItem> GetEvents(List<Lesson> lessons)
        {
            var events = new List<CalendarItem>();
            foreach (var lesson in lessons)
            {
                CalendarItem calendarItem = new CalendarItem()
                {
                    Start = lesson.Start,
                    End = lesson.Finish,
                    Text = _dataMapping.GetLessonTypeName(lesson.LessonTypeId),
                };
                events.Add(calendarItem);
            }
            return events;
        }

        private void Subscribe() { }
    }
}
