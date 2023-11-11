using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using crudapp.Models;

namespace crudapp.DB;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

}
