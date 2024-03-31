using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.MudWeb.Journal.Services;
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

        [Inject] IManageService ManageService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ManageService.Lessons = await ManageService.GetLessonsAsync();
            ManageService.LessonTypes = await ManageService.GetLessonTypesAsync();
            ManageService.Rooms = await ManageService.GetRoomsAsync();
            ManageService.Users = await ManageService.GetUsersAsync();
            ManageService.Levels = await ManageService.GetLevelsAsync();


            _allEvents = GetEvents(ManageService.Lessons);
            _myEvents = GetEvents(ManageService.Lessons.Where(e => e.UserId == 1).ToList());
        }

        private void OnClick(CalendarItem caledarItem)
        {
            int index = _allEvents.IndexOf(caledarItem);
            _selectedLesson = ManageService.Lessons[index];
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
                    Text = ManageService.LessonTypes.FirstOrDefault(e=>e.Id.Equals(lesson.LessonTypeId)).Name,
                };
                events.Add(calendarItem);
            }
            return events;
        }

        private void Subscribe()
        {
            //ManageService.SubscribeToLesson(_selectedLesson.Id, _currentUser.Id);
        }
    }
}
