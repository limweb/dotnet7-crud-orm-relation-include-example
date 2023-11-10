using System;
using System.Collections.Generic;

namespace crudapp.Models;

public partial class Tag
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Article> Articles { get; set; } = new List<Article>();
}
