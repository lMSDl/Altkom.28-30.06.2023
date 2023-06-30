namespace Services.Interfaces
{
    public interface IService<T> where T : ICloneable
    {
        IEnumerable<T> Read();
        void Delete(int id);
        void Edit(int id, T entity);

    }
}