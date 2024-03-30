using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.Services.BS_ClientManagement.Abstractions;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class UsersDataComponent
    {
        [Inject]
        public IClientManagement ClientManagement { get; set; }

        private List<User>? _users;

        protected override async Task OnInitializedAsync()
        {
            //_users = _dataMapping.UsersDTO;
            _users = await ClientManagement.GetAllClientsAsync(new CancellationToken());
            DateOnly startDay = new DateOnly(2023, 8, 17);
        }
    }
}
