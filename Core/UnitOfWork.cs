using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudapp.DB;
using crudapp.Interface;

namespace crudapp.Core
{
 public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        TRepository IUnitOfWork.GetRepository<TRepository, TEntity>()
        {
            var type = typeof(TEntity);

            if (_repositories.ContainsKey(type))
            {
                return (TRepository)_repositories[type];
            }
            else
            {
                var repositoryType = typeof(TRepository);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (TRepository)_repositories[type];
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}