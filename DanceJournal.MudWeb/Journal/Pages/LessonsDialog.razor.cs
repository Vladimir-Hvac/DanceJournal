using DanceJournal.MudWeb.Journal.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Pages
{
    public partial class LessonsDialog
    {
        private string _name = string.Empty;
        private string _type = "Групповое";
        private double _price;
        private string _selectedTypeName;
        private string _selectedName;


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



        private void Submit()
        {
            //if (Lesson?.Name is null)
            //{
            //    Lesson = new LessonType()
            //    {
            //        Name = _name,
            //        Type = _type,
            //        Price = _price
            //    };
            //}
            //else
            //{
            //    Lesson.Name = _name;
            //    Lesson.Type = _type;
            //    Lesson.Price = _price;
            //}

            MudDialog.Close(DialogResult.Ok(Lesson));

        }

        private void Cancel() => MudDialog.Cancel();
    }
}
