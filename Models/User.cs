using System;
using System.Collections.Generic;

namespace crudapp.Models;

public partial class User
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public ICollection<Role> Roles { get; set; } = new List<Role>();
}
