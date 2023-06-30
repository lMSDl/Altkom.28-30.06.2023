namespace Services.Interfaces
{
    public interface IAsyncService<T> where T : ICloneable
    {
        Task<IEnumerable<T>> ReadAsync();
        Task DeleteAsync(int id);
        Task EditAsync(int id, T entity);

    }
}