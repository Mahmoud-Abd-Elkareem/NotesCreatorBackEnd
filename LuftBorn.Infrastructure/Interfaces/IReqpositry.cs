using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftBorn.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> InsertAsync(T obj);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(Guid id);
    }
}
