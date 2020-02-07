using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Repository
{
    public class InMemoryRepository<T, I> : IRepository<T, I>
        where T : IStoreable<I>
    {
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Get(I id)
        {
            throw new NotImplementedException();
        }
        public void Delete(I id)
        {
            throw new NotImplementedException();
        }

        public void Save(T item)
        {
            throw new NotImplementedException();
        }
    }
}
