namespace DanceJournal.MudWeb.Journal.Pages
{
    partial class UsersDataComponent
    {
        private List<User>? _users;

        protected override async Task OnInitializedAsync()
        {
            _users = new List<User>();
            DateOnly startDay = new DateOnly(2023, 8, 17);
            _users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Doe",
                    Age = 30,
                    Gender = "Male",
                    Email = "john.doe@example.com",
                    PhoneNumber = "1234567890",
                    LevelId = 1,
                    RoleId = 1,
                    SubscriptionId = 1,
                    Salary = 50000.00,
                    Role = new Role { Id = 1, Name = "Admin" },
                    Subscription = new Subscription
                    {
                        Id = 1,
                        StartDay = new DateTime(2023817),
                        FinishDay = new DateTime(20240112),
                        SubscriptionType = new SubscriptionType()
                        {
                            ContDay = 15,
                            Name = "FirstClass",
                            Price = 1200,
                        }
                    },
                    Level = new Level
                    {
                        Id = 1,
                        Title = "Intermediate",
                        Coefficient = 0.85
                    },
                    Lessons = new List<Lesson>(),
                    LessonUsers = new List<LessonUser>()
                },
                new User
                {
                    Id = 2,
                    Name = "Jane",
                    Surname = "Smith",
                    Age = 25,
                    Gender = "Female",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "9876543210",
                    LevelId = 2,
                    RoleId = 2,
                    SubscriptionId = 2,
                    Salary = 40000.00,
                    Role = new Role { Id = 2, Name = "User" },
                    Subscription = new Subscription
                    {
                        Id = 1,
                        StartDay = new DateTime(2023817),
                        FinishDay = new DateTime(20240112),
                        SubscriptionType = new SubscriptionType()
                        {
                            ContDay = 15,
                            Name = "FirstClass",
                            Price = 1200,
                        }
                    },
                    Level = new Level
                    {
                        Id = 1,
                        Title = "Beginner",
                        Coefficient = 0.85
                    },
                    Lessons = new List<Lesson>(),
                    LessonUsers = new List<LessonUser>()
                },
                // Add more users as needed
            };
        }
    }
}
