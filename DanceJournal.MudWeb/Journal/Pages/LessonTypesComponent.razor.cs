using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.MudWeb.Journal.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace DanceJournal.MudWeb.Journal.Pages
{

    partial class LessonTypesComponent
    {
        [Inject] public IManageService ManageService { get; set; }


        private string _searchString;

        protected override async Task OnInitializedAsync()
        {
            ManageService.LessonTypes = await ManageService.GetLessonTypesAsync(); 
        }

        private bool FilterFunc1(LessonType element) => FilterFunc(element, _searchString);

        private bool FilterFunc(LessonType element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Price.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Type.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }

}
