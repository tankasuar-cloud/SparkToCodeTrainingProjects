using EFCorePart2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCorePart2
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Enrolls> Enrolls { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Faculity> Faculity { get; set; }
        public DbSet<Hostel> Hostel { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> subject { get; set; }
        public DbSet<Takes> Takes { get; set; }
        public DbSet<TeachesSubject> TeachesSubject { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-M0VN2VQ\\SQLEXPRESS;Database=College;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
