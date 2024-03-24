using DanceJournal.MudWeb.Journal.Pages;
using DanceJournal.Services.BS_ClientManagement.Abstractions;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Services
{
    public interface IManageService
    {
        List<LessonType> LessonTypes { get; set; }
        List<Lesson> Lessons { get; set; }
        List<Room> Rooms { get; set; }
        List<User> Users { get; set; }

        public Task UpdateAsync(object entity);
        public Task AddAsync(object entity);
        public Task CopyAsync(object entity);
        public Task RemoveAsync(object entity);
    }
    public class ManageService : IManageService
    {
        private IDialogService _dialogService;
        private ILessonPlanning _lessonPlanning;
        private IClientManagement _clientManagement;

        public List<Lesson> Lessons { get; set; }
        public List<LessonType> LessonTypes { get; set; }
        public List<Room> Rooms { get; set; }
        public List<User> Users { get; set; }
        public ManageService(IDialogService dialogService, ILessonPlanning lessonPlanning, IClientManagement clientManagement)
        {
            _dialogService = dialogService;
            _lessonPlanning = lessonPlanning;
            _clientManagement = clientManagement;

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
            };
            var result = await OpenDialog("Редактировать", entity, parameters);
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
    }
}
