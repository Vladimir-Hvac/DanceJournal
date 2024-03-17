using DanceJournal.Domain.Models;

namespace DanceJournal.MudWeb.Journal.Models
{
    public class UpsertInvitationVM
    {
        public event EventHandler? OnSelectedLessonChanged;
        public CurrentAuthUser? CurrentAuthUser { get; set; }
        public List<Lesson> Lessons { get; set; } = new();
        private Lesson? _lesson;
        public Lesson? SelectedLesson
        {
            get
            {
                return _lesson;
            }
            set
            {
                _lesson = value;
                OnSelectedLessonChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public List<User> Recipients { get; set; } = new();
        public List<User> SelectedUsers { get; set; } = new();

        public int UserLimit { get; set; }

        public string InvitationBody { get; set; } = string.Empty;
    }
}
