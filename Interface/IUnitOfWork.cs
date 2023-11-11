using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudapp.Core;
using crudapp.Models;
using crudapp.Services;

namespace crudapp.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository, TEntity>() where TRepository : class, IRepositoryBase<TEntity> where TEntity : ModelBase;
        Task SaveAsync();
    }
}