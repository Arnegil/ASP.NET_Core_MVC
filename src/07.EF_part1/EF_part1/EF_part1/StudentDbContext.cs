using System;
using System.Collections.Generic;
using System.Text;
using EF_part1.DBModels;
using Microsoft.EntityFrameworkCore;

namespace EF_part1
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
        }
    }
}
