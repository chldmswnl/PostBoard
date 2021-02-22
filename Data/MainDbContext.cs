using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostsBaord.Models;


namespace PostsBaord.Data
{
    public class MainDbContext : DbContext
    {
        public IConfiguration Configuration { get; set; }

        public MainDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public MainDbContext()
        {
        }

        // set => element should be unique
        public DbSet<Post> Posts { get; set; }

  
        public DbSet<PostComment> PostComment { get; set; }

        public DbSet<PostCategory> PostCategory { get; set; }

  

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var host = Environment.GetEnvironmentVariable("SQL_HOST");
            var schema = Environment.GetEnvironmentVariable("SQL_SCHEMA");
            var userName = Environment.GetEnvironmentVariable("SQL_USERNAME");
            var password = Environment.GetEnvironmentVariable("SQL_PASSWORD");

            options.UseMySQL(
                $"server={host};database={schema};user={userName};password={password}"
             );
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
        }
    }
}
