using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudapp.Core;
using crudapp.DB;
using crudapp.Interface;
using crudapp.Models;

namespace crudapp.Properties
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {

        public ArticleRepository(DataContext context) : base(context)
        {
            
        }


    }
}