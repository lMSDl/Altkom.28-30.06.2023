using Models;
using Services.Bogus.Fakers;
using Services.Interfaces;

namespace Services.Bogus
{
    public class AsyncService<T> : Service<T>, IAsyncService<T> where T : Entity
    {
        public AsyncService(BaseFaker<T> faker) : base(faker)
        {
        }

        public Task DeleteAsync(int id)
        {
            return Task.Run(() => Delete(id) );
        }

        public Task EditAsync(int id, T entity)
        {
            return Task.Run(() => Edit(id, entity));
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            await Task.Delay(5000);
            return Read();
        }
    }
}