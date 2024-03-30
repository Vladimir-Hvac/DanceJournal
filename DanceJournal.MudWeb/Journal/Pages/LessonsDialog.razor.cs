using DanceJournal.MudWeb.Journal.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Pages
{
    public partial class LessonsDialog
    {
        private string _selectedTypeName ;
        private Level _selectedLevel;
        private LessonType _selectedLessonType;
        private Room _selectedRoom;
        private User _selectedTrainer;
        private DateTime? _startDate;
        private TimeSpan? _startTime;
        private DateTime? _endDate;
        private TimeSpan? _endTime;

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public Lesson? Lesson { get; set; }
        [Parameter]
        public List<User>? Users { get; set; }
        [Parameter]
        public List<Room>? Rooms { get; set; }
        [Parameter]
        public List<LessonType>? LessonTypes { get; set; }
        [Parameter]
        public List<Level>? Levels { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Lesson.Id>0)
            {
                _selectedTypeName = Lesson.LessonType.Type;
                _selectedLevel = Lesson.Level;
                _selectedLessonType = Lesson.LessonType;
                _selectedRoom = Lesson.Room;
                _selectedTrainer = Lesson.User;
                _startDate = Lesson.Start.Date;
                _startTime = Lesson.Start.TimeOfDay;
                _endDate = Lesson.Finish.Date;
                _endTime = Lesson.Finish.TimeOfDay;
            }
        }
        private void Submit()
        {
            if (Lesson.Id == 0)
            {
                _startDate.Value.AddHours(_startTime.Value.Hours);
                _startDate.Value.AddMinutes(_startTime.Value.Minutes);
                _endDate.Value.AddHours(_endTime.Value.Hours);
                _endDate.Value.AddMinutes(_endTime.Value.Minutes);

                Lesson.Finish = _endDate ?? DateTime.Now;
                Lesson.LessonType = _selectedLessonType;
                Lesson.LevelId = 1;
                Lesson.Room = _selectedRoom;
                Lesson.Start = _startDate?? DateTime.Now;
                Lesson.User = _selectedTrainer;

            }
            
            MudDialog.Close(DialogResult.Ok(Lesson));

        }

        private void Cancel() => MudDialog.Cancel();
    }
}
