using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Pages
{
    public partial class LessonTypesDialog
    {
        private string _name = string.Empty;
        private string _type = "Групповое";
        private double _price;

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public LessonType? LessonType { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (LessonType?.Name is not null) 
            {
                _name = LessonType.Name;
                _type = LessonType.Type;
                _price = LessonType.Price;
            }
        }

        private void Submit()
        {
            if (LessonType?.Name is null)
            {
                LessonType = new LessonType()
                {
                    Name = _name,
                    Type = _type,
                    Price = _price
                };
            }
            else
            {
                LessonType.Name = _name;
                LessonType.Type = _type;
                LessonType.Price = _price;  
            }

            MudDialog.Close(DialogResult.Ok(LessonType));

        }

        private void Cancel() => MudDialog.Cancel();
    }
}
