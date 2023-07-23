using Microsoft.EntityFrameworkCore;
using Notes.Models;

namespace Notes.Data;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Note?> Notes { get; set; }
}