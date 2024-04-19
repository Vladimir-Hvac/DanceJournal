using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.MudWeb.Journal.Services;
using DanceJournal.Services.BS_ClientManagement.Abstractions;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class UsersDataComponent
    {
        private string _searchString;
        private bool render = false;

        [Inject]
        public IManageService ManageService { get; set; }


        protected override async Task OnInitializedAsync()
        {

            ManageService.Roles = await ManageService.GetRoles();
            ManageService.Levels = await ManageService.GetLevelsAsync();
            ManageService.SubscriptionTypes = await ManageService.GetAllSubscriptionType();
            ManageService.Subscriptions = await ManageService.GetAllSubscription();
            ManageService.Users = await ManageService.GetUsersAsync();
        }

        private bool FilterFunc1(User element) => FilterFunc(element, _searchString);

        private bool FilterFunc(User element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Id.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.BirthDate.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Gender.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Level.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Role.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Salary.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Subscription.SubscriptionType.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Surname.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

    }
}
