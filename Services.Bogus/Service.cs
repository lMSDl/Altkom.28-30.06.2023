using Models;
using Services.Bogus.Fakers;
using Services.Interfaces;

namespace Services.Bogus
{
    public class Service<T> : IService<T> where T : Entity
    {
        private ICollection<T> _collection;

        public Service(BaseFaker<T> faker)
        {
            _collection = faker.Generate(15);
        }

        public void Delete(int id)
        {
            _collection.Remove(_collection.SingleOrDefault(x => x.Id == id));
        }

        public void Edit(int id, T entity)
        {
            entity.Id = id;
            Delete(id);
            _collection.Add(entity);
        }

        public IEnumerable<T> Read()
        {
            return _collection.Select(x => x.Clone()).Cast<T>().ToList();
        }
    }
}