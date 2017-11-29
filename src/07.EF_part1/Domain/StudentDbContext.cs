using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class StudentDbContext : DbContext
    {
        private const string ConnectionString =
            "Server=(localdb)\\mssqllocaldb;" +
            "Database=StudentsDb;" +
            "Trusted_Connection=True;" +
            "MultipleActiveResultSets=true;";

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
            options.UseSqlServer(ConnectionString);
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
