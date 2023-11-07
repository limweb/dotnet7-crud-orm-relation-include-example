using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using crudapp.Models;

namespace crudapp.DB;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)  {  }

    public   DbSet<Address> Addresses { get; set; }
    public   DbSet<Person> Persons { get; set; }
    public   DbSet<Employee> Employees { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseSqlite("DataSource=MainDb.db");

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Address>(entity =>
    //     {
    //         entity.HasIndex(e => e.PersonId, "IX_Addresses_PersonId");

    //         entity.Property(e => e.Pobox).HasColumnName("POBox");

    //         entity.HasOne(d => d.Person).WithMany(p => p.Addresses).HasForeignKey(d => d.PersonId);
    //     });

    //     OnModelCreatingPartial(modelBuilder);
    // }

    // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
