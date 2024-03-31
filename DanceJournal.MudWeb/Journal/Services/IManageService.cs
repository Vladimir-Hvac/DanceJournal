using DanceJournal.MudWeb.Journal.Pages;
using DanceJournal.Services.BS_AbonementManagement.Abstractions;
using DanceJournal.Services.BS_ClientManagement.Abstractions;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Services
{
    public interface IManageService
    {
        public List<Lesson> Lessons { get; set; }
        public List<LessonType> LessonTypes { get; set; }
        public List<Room> Rooms { get; set; }
        public List<User> Users { get; set; }
        public List<Level> Levels { get; set; }
        public List<Role> Roles { get; set; }
        public List<Subscription> Subscription { get; set; }

        public Task<List<Lesson>> GetLessonsAsync();
        public Task<List<LessonType>> GetLessonTypesAsync();
        public Task<List<Room>> GetRoomsAsync();
        public Task<List<User>> GetUsersAsync();
        public Task<List<Level>> GetLevelsAsync();
        public Task<List<Role>> GetRoles();
        public Task<List<Subscription>> GetAllSubscription();

        public Task UpdateAsync(object entity);
        public Task AddAsync(object entity);
        public Task CopyAsync(object entity);
        public Task RemoveAsync(object entity);

        public Task SubscribeToLesson(int lessonId, int userId);
    }
    public class ManageService : IManageService
    {
        private IDialogService _dialogService;
        private ILessonPlanning _lessonPlanning;
        private IClientManagement _clientManagement;
        private IAbonementService _abonementService;

        public List<Lesson> Lessons { get; set; }
        public List<LessonType> LessonTypes { get; set; }
        public List<Room> Rooms { get; set; }
        public List<User> Users { get; set; }
        public List<Level> Levels { get; set; }
        public List<Role> Roles { get; set; }
        public List<Subscription> Subscription { get; set; }


        public ManageService(IDialogService dialogService,
            ILessonPlanning lessonPlanning,
            IClientManagement clientManagement,
            IAbonementService abonementService)
        {
            _dialogService = dialogService;
            _lessonPlanning = lessonPlanning;
            _clientManagement = clientManagement;
            _abonementService = abonementService;

        }


        public async Task UpdateAsync(object entity)
        {
            switch (entity)
            {
                case LessonType _:
                    await UpdateLessonTypesAsync(entity);
                    break;
                case Lesson _:
                    await UpdateLessonsAsync(entity);
                    break;
                default:
                    break;
            }
        }

        public async Task AddAsync(object entity)
        {
            switch (entity)
            {
                case LessonType _:
                    await AddLessonTypesAsync(entity);
                    break;
                case Lesson _:
                    await AddLessonsAsync(entity);
                    break;
                default:
                    break;
            }
        }

        public async Task CopyAsync(object entity)
        {
            switch (entity)
            {
                case LessonType entityAsType:
                    entityAsType.Id = 0;
                    LessonTypes.Add(entityAsType);
                    await _lessonPlanning.CreateLessonTypeAsync(entityAsType);
                    break;
                case Lesson entityAsType:
                    entityAsType.Id = 0;
                    Lessons.Add(entityAsType);
                    await _lessonPlanning.CreateLessonAsync(entityAsType);
                    break;
                default:
                    break;
            }
        }

        public async Task RemoveAsync(object entity)
        {
            switch (entity)
            {
                case LessonType entityAsType:
                    LessonTypes.Remove(entityAsType);
                    await _lessonPlanning.DeleteLessonType(entityAsType.Id);
                    break;
                case Lesson entityAsType:
                    Lessons.Remove(entityAsType);
                    await _lessonPlanning.DeleteLesson(entityAsType.Id);
                    break;
                default:
                    break;
            }

        }

        private async Task<DialogResult> OpenDialog(string title, object entity)
        {
            Type dialogType = GetDialogType(entity);

            if (dialogType == null) { DialogResult.Cancel(); }
            var parameters = new DialogParameters()
            {
                {entity.GetType().Name,entity}
            };
            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = _dialogService.Show(dialogType, title, parameters, options);
            return await dialog.Result;
        }

        private async Task<DialogResult> OpenDialog(string title, object entity, DialogParameters parameters)
        {
            Type dialogType = GetDialogType(entity);

            if (dialogType == null) { DialogResult.Cancel(); }

            var options = new DialogOptions { CloseOnEscapeKey = true };
            var dialog = _dialogService.Show(dialogType, title, parameters, options);
            return await dialog.Result;
        }

        private Type GetDialogType(object entity)
        {
            switch (entity)
            {
                case Lesson _: return typeof(LessonsDialog);

                case LessonType: return typeof(LessonTypesDialog);
                default:
                    return null;
            }
        }

        private async Task AddLessonTypesAsync(object entity)
        {
            var result = await OpenDialog("Добавить", entity);
            if (result.Canceled) return;
            var resultEntity = (LessonType)result.Data;
            LessonTypes.Add(resultEntity);
            await _lessonPlanning.CreateLessonTypeAsync(resultEntity);

        }

        private async Task UpdateLessonTypesAsync(object entity)
        {
            var result = await OpenDialog("Редактировать", entity);
            if (result.Canceled) return;

            LessonType resultEntity = (LessonType)result.Data;
            LessonType? oldData = LessonTypes.FirstOrDefault(x => x.Id.Equals(resultEntity.Id));
            if (oldData is null) { return; }
            resultEntity.Id = oldData.Id;
            LessonTypes.Remove(oldData);
            LessonTypes.Add(resultEntity);
            await _lessonPlanning.UpdateLessonTypeAsync(resultEntity);

        }

        private async Task AddLessonsAsync(object entity)
        {
            var parameters = new DialogParameters()
            {
                {entity.GetType().Name,entity},
                {nameof(this.LessonTypes),LessonTypes },
                {nameof(this.Rooms),Rooms },
                {nameof(this.Users),Users },
                {nameof(this.Levels),Levels },
            };
            var result = await OpenDialog("Добавить", entity, parameters);
            if (result.Canceled) return;

            Lesson resultEntity = (Lesson)result.Data;
            Lessons.Add(resultEntity);
            await _lessonPlanning.CreateLessonAsync(resultEntity);

        }

        private async Task UpdateLessonsAsync(object entity)
        {
            var parameters = new DialogParameters()
            {
                {entity.GetType().Name,entity},
                {nameof(this.LessonTypes),LessonTypes },
                {nameof(this.Rooms),Rooms },
                {nameof(this.Users),Users },
                {nameof(this.Levels),Levels },
            };
            var result = await OpenDialog("Редактировать", entity, parameters);
            if (result.Canceled) return;

            Lesson resultEntity = (Lesson)result.Data;
            Lesson? oldData = Lessons.FirstOrDefault(x => x.Id.Equals(resultEntity.Id));
            if (oldData is null) { return; }
            resultEntity.Id = oldData.Id;
            Lessons.Remove(oldData);
            Lessons.Add(resultEntity);
            await _lessonPlanning.UpdateLessonAsync(resultEntity);

        }

        public async Task<List<Lesson>> GetLessonsAsync()
        {
            List<Lesson> lessons = new List<Lesson>();
            var test = await _lessonPlanning.GetAllLessonsAsync();
            lessons = test.ToList();
            return lessons;
        }

        public async Task<List<LessonType>> GetLessonTypesAsync()
        {
            List<LessonType> lessonTypes = new List<LessonType>();
            var test = await _lessonPlanning.GetAllLessonsTypesAsync();
            lessonTypes = test.ToList();
            return lessonTypes;
        }

        public async Task<List<Room>> GetRoomsAsync()
        {
            List<Room> rooms = new List<Room>();
            var test = await _lessonPlanning.GetAllRoomsAsync();
            rooms = test.ToList();
            return rooms;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> users = new List<User>();
            var test = await _clientManagement.GetAllClientsAsync(new CancellationToken());
            users = test.ToList();
            return users;
        }

        public async Task<List<Level>> GetLevelsAsync()
        {
            List<Level> levels = new List<Level>();
            var test = await _lessonPlanning.GetAllLevelsAsync();
            levels = test.ToList();
            return levels;
        }
        public async Task SubscribeToLesson(int lessonId,int userId)
        {
            var lessonUser = new LessonUser() { IsVisit = true, LessonId = lessonId,UserId = userId };
            await _lessonPlanning.CreateLessonUserAsync(lessonUser);
        }
        public async Task<List<Role>> GetRoles()
        {
            List<Role> roles = new List<Role>();
            var test = await _clientManagement.GetAllRolesAsync();
            roles = test.ToList();
            return roles;
        }
        public async Task<List<Subscription>> GetAllSubscription()
        {
            List<Subscription> subscription = new List<Subscription>();
            var test = await _abonementService.GetAllAbonementsAsync(new CancellationToken());
            subscription = test.ToList();
            return subscription;
        }

    }
}
