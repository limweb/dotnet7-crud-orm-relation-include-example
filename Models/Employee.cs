using System;
using System.Collections.Generic;

namespace crudapp.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string Salary { get; set; } = null!;
}
