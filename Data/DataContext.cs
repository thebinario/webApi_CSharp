using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using webApi.Models;

namespace webApi.Data
{
    public class DataContext : DbContext
    {
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }

        private const string ConnectionString = "server=localhost;user id=root;password=root;database=StudyApi;convert zero datetime=True;pooling=false";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ConnectionString,
                         MySqlServerVersion.LatestSupportedServerVersion
                        );
            }
        }
    }
}