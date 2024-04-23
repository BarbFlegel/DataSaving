using DataSaving.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataSaving.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Contact> Contacts { get; set; }
}
