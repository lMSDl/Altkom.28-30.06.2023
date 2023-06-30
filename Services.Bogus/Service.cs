using Services.Bogus.Fakers;
using Services.Interfaces;

namespace Services.Bogus
{
    public class Service<T> : IService<T> where T : class
    {
        private ICollection<T> _collection;

        public Service(BaseFaker<T> faker)
        {
            _collection = faker.Generate(15);
        }

        public void Delete(T item)
        {
            _collection.Remove(item);
        }

        public IEnumerable<T> Read()
        {
            return _collection.ToList();
        }
    }
}