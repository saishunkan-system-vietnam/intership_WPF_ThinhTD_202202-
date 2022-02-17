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
            modelBuilder.ApplyConfiguration(new InterviewConfiguration());
            modelBuilder.ApplyConfiguration(new Candidate_ApplyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new InterviewConfiguration());
            modelBuilder.ApplyConfiguration(new Interview_EmployeeConfiguration());
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
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Candidate_Apply> Candidate_Apply { get; set; }
        public DbSet<Interview> Interview { get; set; }
        public DbSet<Interview_Employee> interview_Employee { get; set; }
    }
}
