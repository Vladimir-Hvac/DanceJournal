using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class UsersDataComponent
    {
        [Inject]
        public DataMapping _dataMapping { get; set; }
        private List<User>? _users;

        protected override async Task OnInitializedAsync()
        {
            _users = _dataMapping.UsersDTO;
            DateOnly startDay = new DateOnly(2023, 8, 17);
        }
    }
}
