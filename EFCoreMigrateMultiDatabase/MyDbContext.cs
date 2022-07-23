using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreMigrateMultiDatabase;

public class MyDbContext:DbContext
{
    public DbSet<User> Users { get; set; }
    public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
    {
        
    }
}