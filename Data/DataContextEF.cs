using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DataContextEF : DbContext
    {
        private readonly string? _connectionString;
        public DataContextEF(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        public DbSet<Computer> Computer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    _connectionString,
                    options => options.EnableRetryOnFailure()
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // setting default schema - eg default is dbo
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            modelBuilder.Entity<Computer>()
            // .HasNoKey()
            .HasKey(c => c.ComputerId);
            // .ToTable("Computer", "TutorialAppSchema")
            // .ToTable("TableName", "SchemaName")
        }
    }
}