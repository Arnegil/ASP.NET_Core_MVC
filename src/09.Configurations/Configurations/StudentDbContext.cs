using System;
using System.Collections.Generic;
using System.Text;
using Configurations.DBModels;
using Microsoft.EntityFrameworkCore;

namespace Configurations
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<StudentDBModel> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDBModel>().ToTable("Students");
            modelBuilder.Entity<StudentDBModel>()
                .Property(x => x.BirthDate)
                .IsRequired();
        }
    }
}
