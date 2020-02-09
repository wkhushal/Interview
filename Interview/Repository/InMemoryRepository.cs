using Interview.Model;
using Interview.Store;
using Interview.Storeable;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Interview.Repository
{
    public class InMemoryRepository : IRepository<IStoreable<Person>, Person>
    {
        private readonly IStore _store;
        public InMemoryRepository(IStore store)
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
        }

        public IEnumerable<IStoreable<Person>> GetAll()
        {
            var getAllTask = _store.GetAllAsync(default);
            getAllTask.Wait();
            return getAllTask.Result.Select(item => new PersonStore { Id = item } as IStoreable<Person>);
        }

        public IStoreable<Person> Get(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            var getTask = _store.GetAsync(person.Id, default);

            getTask.Wait();
            if(getTask.Result is null)
            {
                return null;
            }
            return new PersonStore { Id = getTask.Result } as IStoreable<Person>;
        }

        public void Delete(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            var delTask = _store.DeleteAsync(person.Id, default);

            delTask.Wait();
        }

        public void Save(IStoreable<Person> item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            Person person = item.Id;
            var saveTask = _store.SaveAsync(person, default);
            saveTask.Wait();
        }
    }
}
