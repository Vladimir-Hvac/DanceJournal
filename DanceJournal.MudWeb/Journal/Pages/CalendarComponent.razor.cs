﻿using Heron.MudCalendar;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class CalendarComponent
    {
        private List<CalendarItem> _events =
            new()
            {
                new CalendarItem
                {
                    Start = DateTime.Today.AddHours(10),
                    End = DateTime.Today.AddHours(11),
                    Text = "Event today"
                },
                new CalendarItem
                {
                    Start = DateTime.Today.AddDays(1).AddHours(11),
                    End = DateTime.Today.AddDays(1).AddHours(12.5),
                    Text = "Event tomorrow"
                }
            };
    }
}
