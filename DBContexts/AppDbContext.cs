using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Configurations;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        public AppDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PresenterConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=192.168.10.51;Initial Catalog=CVManagement; User Id = sa; Password = 20150601");
        }

        public DbSet<Presenter> Presenter { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Titles> Titles { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
    }
}
