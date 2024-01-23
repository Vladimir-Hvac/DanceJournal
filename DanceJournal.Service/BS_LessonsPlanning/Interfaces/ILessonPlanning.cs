public interface ILessonPlanning
{
    //Получить список всех занятий
    public IEnumerable<Lesson> GetAllLessons();

    //Получить информацию о занятии
    public Lesson GetLesson(Lesson lesson);

    //Добавить занятие
    public Task AddLesson(Lesson lesson);

    //Редактировать занятие
    public Task UpdateLesson(Lesson lesson);

    //Удалить занятие
    public Task RemoveLesson(Lesson lesson);

    //Получить список всех залов
    public IEnumerable<Room> GetAllRooms();

    //Забронировать зал
    //При отправке Room бронируется зал для урока
    //При отправке Room = null, бронирование снимается, а в Lesson.RoomId заполняется 0
    public Task BookRoom(Lesson lesson, Room room);
}
