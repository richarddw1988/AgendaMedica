using AM.Domain.Models;
using AM.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace AM.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IHostingEnvironment _env;

        public AppDbContext(IHostingEnvironment env)
        {
            _env = env;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IEntityConfig).IsAssignableFrom(x) && !x.IsAbstract).ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }

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

        public DbSet<UserEntity> Users { get; set; }
    }
}
