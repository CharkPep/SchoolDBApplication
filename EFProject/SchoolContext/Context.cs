using EFProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EFProject
{
    public class SchoolContext : DbContext
    {
        // DbSets for each model
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentInfo> StudentInfos { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        // Connection string for the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["SchoolDB"].ConnectionString);
        }
    }
}
