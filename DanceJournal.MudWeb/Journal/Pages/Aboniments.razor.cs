using System;
using DanceJournal.MudWeb.Journal.Services;
using Microsoft.AspNetCore.Components;

namespace DanceJournal.MudWeb.Journal.Pages
{
	public partial class Aboniments
	{
		[Inject]
		public IManageService ManageService {get;set;}

		protected override async Task OnInitializedAsync()
		{
			ManageService.SubscriptionTypes = await ManageService.GetAllSubscriptionType();
			ManageService.Subscriptions = await ManageService.GetAllSubscription();

        }

    }
}

