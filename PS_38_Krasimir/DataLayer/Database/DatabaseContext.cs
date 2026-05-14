using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            //Create a user
            var user1 = new DatabaseUser()
            {
                Id = 1,
                Name = "John Doe",
                Password = "1234",
                FacNumber = "none",
                Email = "john@email.com",
                Role = Welcome.Others.UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10),
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user1);

            var user2 = new DatabaseUser()
            {
                Id = 2,
                Name = "Albert Jackson",
                Password = "5678",
                FacNumber = "none",
                Email = "alby@email.com",
                Role = Welcome.Others.UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddYears(6),
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user2);

            var user3 = new DatabaseUser()
            {
                Id = 3,
                Name = "Donald Duck",
                Password = "9876",
                FacNumber = "121223008",
                Email = "donyd@email.com",
                Role = Welcome.Others.UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(2),
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user3);
        }

        public DbSet<DatabaseUser>Users { get; set; }

        public DbSet<DatabaseLog>Logs { get; set; }

    }
}
