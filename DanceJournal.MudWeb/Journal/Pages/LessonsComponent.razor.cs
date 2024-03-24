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
        public DataMapping DataMapping { get; set; }
        [Inject]
		public ILessonPlanning LessonPlanning { get; set; }
        [Inject]
        public IClientManagement ClientManagement { get; set; }

        [Inject]
		public IManageService ManageService { get; set; }

		private string _searchString;

		protected override async Task OnInitializedAsync()
		{
			var lessons = await LessonPlanning.GetAllLessonsAsync();
			//var lessons = DataMapping.LessonsDTO;
            ManageService.Lessons = lessons.ToList();
            var lessonTypes = await LessonPlanning.GetAllLessonsTypesAsync();
            ManageService.LessonTypes = lessonTypes.ToList();
            var rooms = await LessonPlanning.GetAllRoomsAsync();
            ManageService.Rooms = rooms.ToList();
            var users = await ClientManagement.GetAllClientsAsync(_cancellationToken);
            ManageService.Users = users.ToList();

        }

        private bool FilterFunc1(Lesson element) => FilterFunc(element, _searchString);

		private bool FilterFunc(Lesson element, string searchString)
		{
			if (string.IsNullOrWhiteSpace(searchString))
				return true;
			if (element.LessonType.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
				return true;
			if (element.LessonType.Price.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
				return true;
			if (element.LessonType.Type.Contains(searchString, StringComparison.OrdinalIgnoreCase))
				return true;
			return false;
		}
	}
}
