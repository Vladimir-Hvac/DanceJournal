namespace DanceJournal.Infrastructure.Repository
{
    public interface IDanceJournalRepository
    {
        Task AddEntityAsync<T>(T entity)
            where T : class;
        List<T>? GetAllEntitiesByType<T>()
            where T : class;
        T? GetEntityOrDefault<T>(T entity)
            where T : class;
        Task RemoveEntityAsync<T>(T entity)
            where T : class;
        Task UpdateEntityAsync<T>(T entity)
            where T : class;
    }
}
