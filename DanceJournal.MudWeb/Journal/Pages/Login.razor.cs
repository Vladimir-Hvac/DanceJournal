using DanceJournal.MudWeb.Journal.Models;
using DanceJournal.MudWeb.Journal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class Login
    {
        [Inject] IManageService ManageService { get; set; }
        protected override async Task OnInitializedAsync()
        {

        }

        private void HandleValidSubmit() { }
    }
}
