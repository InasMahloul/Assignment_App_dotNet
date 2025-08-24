using Assignment_App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Assignment_App.Domain.Entities;

namespace Assignment_App.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TodoTask> TodoTasks => Set<TodoTask>();
    }
}
