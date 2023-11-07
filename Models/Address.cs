using System;
using System.Collections.Generic;

namespace crudapp.Models;

public partial class Address
{
    public long Id { get; set; }

    public string Country { get; set; } = null!;

    public string Pobox { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string Apartment { get; set; } = null!;

    public long PersonId { get; set; }

    public string CreatedAt { get; set; } = null!;

    public string UpdatedAt { get; set; } = null!;

    public Person  Person { get; set; } = null!;

}
