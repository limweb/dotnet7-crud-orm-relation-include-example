using System;
using System.Collections.Generic;

namespace crudapp.Models;

public partial class Role
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}
