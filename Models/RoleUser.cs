using System;
using System.Collections.Generic;

namespace crudapp.Models;

public partial class RoleUser
{
    public long Id { get; set; }

    public long? UsersId { get; set; }

    public long? RolesId { get; set; }
}
