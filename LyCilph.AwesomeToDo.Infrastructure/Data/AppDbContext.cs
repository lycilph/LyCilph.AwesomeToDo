using LyCilph.AwesomeToDo.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LyCilph.AwesomeToDo.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source=SQLite.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
    