using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudapp.Core;
using crudapp.Models;

namespace crudapp.Services
{
    public interface IRepositoryBase<T> where T : ModelBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> ExistsAsync(int id);
       
    }
}