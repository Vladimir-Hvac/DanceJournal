using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Pages
{
    public partial class LessonsDialog
    {
        private string _name = string.Empty;
        private string _type = "Групповое";
        private double _price;

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public Lesson? Lesson { get; set; }
        protected override async Task OnInitializedAsync()
        {

            //if (Lesson?.Name is not null)
            //{
            //    _name = Lesson.Name;
            //    _type = Lesson.Type;
            //    _price = Lesson.Price;
            //}
        }

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
