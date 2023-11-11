using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudapp.Models;
using crudapp.Services;

namespace crudapp.Interface
{
    public interface IArticleRepository : IRepositoryBase<Article>
    {
        
    }
}