using LuftBorn.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LuftBorn.Infrastructure
{
    public class LuftBornContext : DbContext
    {
        public LuftBornContext(DbContextOptions<LuftBornContext> options) : base(options)
        {

        }
        public DbSet<Note> Notes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
