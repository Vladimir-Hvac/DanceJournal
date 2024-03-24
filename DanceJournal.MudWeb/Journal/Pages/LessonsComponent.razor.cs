using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.MudWeb.Journal.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Pages
{
	public partial class LessonsComponent
	{

		[Inject]
		public ILessonPlanning LessonPlanning { get; set; }

		[Inject]
		public IManageService ManageService { get; set; }

		private string _searchString;

		protected override async Task OnInitializedAsync()
		{
			var lessons = await LessonPlanning.GetAllLessonsAsync();
			ManageService.Lessons = lessons.ToList();
            var lessonTypes = await LessonPlanning.GetAllLessonsTypesAsync();
            ManageService.LessonTypes = lessonTypes.ToList();
            var rooms = await LessonPlanning.GetAllRoomsAsync();
            ManageService.Rooms = rooms.ToList();
            var users = await LessonPlanning.();
            ManageService.Rooms = rooms.ToList().Where(e=>e.);

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
