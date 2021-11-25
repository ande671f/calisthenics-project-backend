using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calisthenics_backend.Interface
{
    public interface IRepository<T>
    {
        public Task Create(T _object);

        public Task Update(string id, T _object);

        public Task<IEnumerable<T>> GetAll();

        public Task<T> GetById(string id);

        public Task Delete(string id);
    }
}
