using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.MudWeb.Journal.Services;
using DanceJournal.Services.BS_ClientManagement.Abstractions;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class UsersDataComponent
    {
        [Inject]
        public IManageService ManageService { get; set; }
        private bool render = false;


        protected override async Task OnInitializedAsync()
        {

            ManageService.Roles = await ManageService.GetRoles();
            ManageService.Levels = await ManageService.GetLevelsAsync();
            ManageService.SubscriptionType = await ManageService.GetAllSubscriptionType();
            ManageService.Subscription = await ManageService.GetAllSubscription();
            ManageService.Users = await ManageService.GetUsersAsync();
            render = true;
        }
    }
}
