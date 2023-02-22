using LuftBorn.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
