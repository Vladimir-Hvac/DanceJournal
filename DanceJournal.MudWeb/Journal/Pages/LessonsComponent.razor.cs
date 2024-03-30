using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.MudWeb.Journal.Services;
using DanceJournal.Services.BS_ClientManagement.Abstractions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Pages
{
	public partial class LessonsComponent
	{
		private CancellationToken _cancellationToken;

        [Inject]
		public IManageService ManageService { get; set; }


		private string _searchString;

		protected override async Task OnInitializedAsync()
		{
			ManageService.Lessons = await ManageService.GetLessonsAsync();
			ManageService.LessonTypes = await ManageService.GetLessonTypesAsync();
			ManageService.Rooms = await ManageService.GetRoomsAsync();
			ManageService.Users = await ManageService.GetUsersAsync();
			ManageService.Levels = await ManageService.GetLevelsAsync();
        }

        private bool FilterFunc1(Lesson element) => FilterFunc(element, _searchString);

		private bool FilterFunc(Lesson element, string searchString)
		{
			if (string.IsNullOrWhiteSpace(searchString))
				return true;
			if (element.LessonType.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
				return true;
			if (element.LessonType.Type.Contains(searchString, StringComparison.OrdinalIgnoreCase))
				return true;
			if (element.Room.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
				return true;
            if (element.User.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Level.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Start.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Finish.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
		}
	}
}
