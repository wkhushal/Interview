using Interview.Store;
using System;
using System.Collections.Generic;

namespace Interview.Repository
{
    public class InMemoryRepository<T, I> : IRepository<T, I>
        where T : IStoreable<I>
    {
        private readonly IStore _store;
        public InMemoryRepository(IStore store)
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Get(I id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            throw new NotImplementedException();
        }

        public void Delete(I id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            throw new NotImplementedException();
        }

        public void Save(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            throw new NotImplementedException();
        }
    }
}
