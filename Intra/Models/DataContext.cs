using Microsoft.EntityFrameworkCore;

namespace Intra.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}