using DanceJournal.MudWeb.Journal.Pages;
using DanceJournal.Services.BS_LessonsPlanning;
using DanceJournal.Services.BS_StaffManagement.Abstractions;
using MudBlazor;

namespace DanceJournal.MudWeb.Journal.Services
{
    public interface IManageService
    {
        List<LessonType> LessonTypes { get; set; }
        List<Lesson> Lessons { get; set; }
        List<Room> Rooms { get; set; }

        public Task UpdateAsync(object entity);
        public Task AddAsync(object entity);
        public Task CopyAsync(object entity);
        public Task RemoveAsync(object entity);
    }
    public class ManageService : IManageService
    {
        private IDbTypeManage _lessonTypesManage;
        private IDialogService _dialogService;
        private ILessonPlanning _lessonPlanning;

        public List<Lesson> Lessons { get; set; }
        public List<LessonType> LessonTypes { get; set; }
        public List<Room> Rooms { get; set; }
        public ManageService(IDbTypeManage lessonTypesManage,  IDialogService dialogService, ILessonPlanning lessonPlanning)
        {
            _lessonTypesManage = lessonTypesManage;
            _dialogService = dialogService;
            _lessonPlanning = lessonPlanning;
        }

        public async Task UpdateAsync(object entity)
        {
            var result = await OpenDialog("Редактировать", entity);
            if (result.Canceled) return;

            switch (entity)
            { 
                case LessonType _:
                    await UpdateLessonTypesAsync(result);
                    break;
                default:
                    break;
            }
        }

        public async Task AddAsync(object entity)
        {
            var result = await OpenDialog("Добавить", entity);
            if (result.Canceled) return;
            switch (entity)
            {
                case LessonType resultEntity:

                    resultEntity = (LessonType)result.Data;
                    LessonTypes.Add(resultEntity);
                    await _lessonPlanning.CreateLessonTypeAsync(resultEntity);
                    break;
                case Lesson resultEntity:
                    resultEntity = (Lesson)result.Data;
                    Lessons.Add(resultEntity);
                    await _lessonPlanning.CreateLessonAsync(resultEntity);
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

        private async Task UpdateLessonTypesAsync(DialogResult result) 
        {
            LessonType resultEntity = (LessonType)result.Data;
            LessonType? oldData = LessonTypes.FirstOrDefault(x => x.Id.Equals(resultEntity.Id));
            if (oldData is null) { return; }
            resultEntity.Id = oldData.Id;
            LessonTypes.Remove(oldData);
            LessonTypes.Add(resultEntity);
            await _lessonPlanning.UpdateLessonTypeAsync(resultEntity);

        }
    }
}
