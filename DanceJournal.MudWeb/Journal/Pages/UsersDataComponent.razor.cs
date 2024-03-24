using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.Services.BS_ClientManagement.Abstractions;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class UsersDataComponent
    {
        [Inject]
        public DataMapping _dataMapping { get; set; }
        [Inject]
        public IClientManagement ClientManagement { get; set; }

        private List<User>? _users;

        protected override async Task OnInitializedAsync()
        {
            //_users = _dataMapping.UsersDTO;
            _users = await ClientManagement.GetAllClientsAsync(new CancellationToken());
            foreach (var user in _users)
            {
                user.Level = _dataMapping.GetLevel(user.LevelId);
                user.Subscription = _dataMapping.GetSubscription(user.SubscriptionId);
                user.Role = _dataMapping.GetRole(user.RoleId);
                user.Subscription.SubscriptionType = _dataMapping.GetSubscriptionType(
                    user.Subscription.SubscriptionTypeId
                );
            }
            DateOnly startDay = new DateOnly(2023, 8, 17);
        }
    }
}
