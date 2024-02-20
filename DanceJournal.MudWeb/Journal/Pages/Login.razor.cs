using DanceJournal.MudWeb.Journal.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class Login
    {
        private string _surName;
        private string _firstName;
        private string _secondName;
        private DateOnly _birthDate;
        private string _gender;
        private string _email;
        private string _phoneNumber;

        public User User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            User = new User()
            {
                Email = _email,
                Surname = _surName,
                FirstName = _firstName,
                SecondName = _secondName,
                BirthDate = _birthDate,
                Gender = _gender,
                PhoneNumber = _phoneNumber,
                RoleId = 1,
                SubscriptionId = 1,
                LevelId = 1,
            };
        }

        private void HandleValidSubmit() { }
    }
}
