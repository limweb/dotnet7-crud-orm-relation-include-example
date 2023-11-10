using System;
using System.Collections.Generic;

namespace crudapp.Models;

public partial class Article
{
    public long Id { get; set; }

    public string? Title { get; set; }

    public string? BodyText { get; set; }

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
