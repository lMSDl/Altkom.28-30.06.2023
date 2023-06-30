namespace Services.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> Read();
        void Delete(T item);

    }
}