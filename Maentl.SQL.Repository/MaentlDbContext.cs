using Maentl.SQL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Maentl.SQL.Repository
{
    public class MaentlDbContext : DbContext
    {
        public MaentlDbContext(DbContextOptions<MaentlDbContext> options)
            : base(options) { }

        public DbSet<WorkEntry> WorkEntries { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EmailActivity> EmailActivities { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: model-level configurations, indices, etc.
        }
    }
}
