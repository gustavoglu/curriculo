using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Curriculo.Infra.Data.Context
{
    public class ContextSQLSFactory : IDesignTimeDbContextFactory<ContextSQLS>
    {
        public ContextSQLS CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<ContextSQLS>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return new ContextSQLS();
        }
    }
}
