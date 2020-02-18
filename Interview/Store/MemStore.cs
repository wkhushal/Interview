using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.Model;
using System.Threading;

namespace Interview.Store
{
    public class MemStore : IStore
    {
        private readonly ConcurrentDictionary<string, Person> _memStore = new ConcurrentDictionary<string, Person>();

        public Task DeleteAsync(string id, CancellationToken ct)
        {
            if (_memStore.TryRemove(id, out var _))
            {
                return Task.CompletedTask;
            }
            return Task.FromResult<Person>(null);
        }

        public Task<IEnumerable<Person>> GetAllAsync(CancellationToken ct)
        {
            return Task.FromResult(_memStore.Select(item => item.Value).ToList() as IEnumerable<Person>);
        }

        public Task<Person> GetAsync(string id, CancellationToken ct)
        {
            if (_memStore.TryGetValue(id, out var person))
            {
                return Task.FromResult(person);
            }
            return Task.FromResult<Person>(null);
        }

        public Task SaveAsync(Person item, CancellationToken ct)
        {
            _memStore.AddOrUpdate(item.Id, item, (key, existing) =>
            {
                if (!item.Equals(existing))
                {
                    throw new ArgumentException("Id");
                }
                existing.BirthDate = item.BirthDate;
                existing.Name = item.Name;
                return existing;
            });
            return Task.CompletedTask;
        }
    }
}
