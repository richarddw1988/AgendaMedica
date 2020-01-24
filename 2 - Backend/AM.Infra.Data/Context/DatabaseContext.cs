using AM.Domain.Models;
using AM.Infra.Data.Mapping;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Infra.Data.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly IHostingEnvironment _env;

        public DatabaseContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public DbSet<UserEntity> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);

            
            //modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}
