using Interview.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interview.Store
{
    public interface IStore
    {
        Task<IEnumerable<Person>> GetAllAsync(CancellationToken ct);
        Task<Person> GetAsync(string id, CancellationToken ct);
        Task DeleteAsync(string id, CancellationToken ct);
        Task SaveAsync(Person item, CancellationToken ct);
    }
}
