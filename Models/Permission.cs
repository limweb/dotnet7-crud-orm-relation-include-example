using System;
using System.Collections.Generic;

namespace crudapp.Models;

public partial class Permission
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Action { get; set; }

    public string? Resources { get; set; }
}
