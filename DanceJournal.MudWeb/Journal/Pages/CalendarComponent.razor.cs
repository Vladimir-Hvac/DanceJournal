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
        private User _currentUser;
        private string _subscribeButtonName = "Записаться";
        private bool _isEnable;

        [Inject] IManageService ManageService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ManageService.Lessons = await ManageService.GetLessonsAsync();
            ManageService.LessonTypes = await ManageService.GetLessonTypesAsync();
            ManageService.Rooms = await ManageService.GetRoomsAsync();
            ManageService.Users = await ManageService.GetUsersAsync();
            ManageService.Roles = await ManageService.GetRoles();
            ManageService.Subscriptions = await ManageService.GetAllSubscription();
            ManageService.SubscriptionTypes = await ManageService.GetAllSubscriptionType();
            ManageService.Levels = await ManageService.GetLevelsAsync();
            ManageService.LessonUsers = await ManageService.GetLessonUsers();

            _currentUser = await ManageService.GetCurrentUser();
            _allEvents = GetEvents(ManageService.Lessons);

            _myEvents = GetEvents(ManageService.LessonUsers
                .Where(e => e.UserId.Equals(_currentUser.Id))
                .Select(e => e.Lesson)
                .ToList());
        }

        private void AllEventsClick(CalendarItem caledarItem)
        {
            int index = _allEvents.IndexOf(caledarItem);
            _selectedLesson = ManageService.Lessons[index];
            _showEvents = !_showEvents;
            _anchor = Anchor.End;
            if (ManageService.LessonUsers.Any(e => e.UserId.Equals(_currentUser.Id))
    && ManageService.LessonUsers.Any(e => e.LessonId.Equals(_selectedLesson.Id)))
            {
                _subscribeButtonName = "Вы записаны";
                _isEnable = true;
            }
            else
            {
                _subscribeButtonName = "Записаться";
                _isEnable = false;
            }
        }
        private void MyEventsClick(CalendarItem caledarItem)
        {
            int index = _myEvents.IndexOf(caledarItem);
            _selectedLesson = ManageService.Lessons[index];
            _showEvents = !_showEvents;
            _anchor = Anchor.End;
            if (ManageService.LessonUsers.Any(e => e.UserId.Equals(_currentUser.Id))
    && ManageService.LessonUsers.Any(e => e.LessonId.Equals(_selectedLesson.Id)))
            {
                _subscribeButtonName = "Вы записаны";
                _isEnable = true;
            }
            else
            {
                _subscribeButtonName = "Записаться";
                _isEnable = false;
            }
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
            ManageService.SubscribeToLesson(_selectedLesson.Id, _currentUser.Id);
            _subscribeButtonName = "Вы записаны";
            _isEnable = true;
        }
    }
}
