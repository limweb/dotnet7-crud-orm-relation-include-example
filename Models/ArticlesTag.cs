using System;
using System.Collections.Generic;

namespace crudapp.Models;

public partial class ArticlesTag
{
    public long TagsId { get; set; }

    public long ArticlesId { get; set; }
}
