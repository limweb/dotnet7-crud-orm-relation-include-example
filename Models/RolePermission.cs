using System;
using System.Collections.Generic;

namespace crudapp.Models;

public partial class RolePermission
{
    public long Id { get; set; }

    public long? RoleId { get; set; }

    public long? PermissionId { get; set; }
}
