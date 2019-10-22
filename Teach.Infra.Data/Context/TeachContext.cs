using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Teach.Infra.Data.Context
{
    public class TeachContext : DbContext
    {
        public TeachContext(
            DbContextOptions<TeachContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //   modelBuilder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(modelBuilder);
        }

        public class NobioContextFactory : IDesignTimeDbContextFactory<TeachContext>
        {

            TeachContext IDesignTimeDbContextFactory<TeachContext>.CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<TeachContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                //builder.UseSqlServer(connectionString);
                builder.UseSqlServer(connectionString);

                return new TeachContext(builder.Options);
            }
        }
    }

}
