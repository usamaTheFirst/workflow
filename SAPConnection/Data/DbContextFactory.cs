using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace SAPConnection.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CustomAppsDatabase;User ID=sa;Password=Appdev@786#;Persist Security Info=False;Integrated Security=False;TrustServerCertificate=true");
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = CustomAppsDatabase; Trusted_Connection = True; MultipleActiveResultSets = true");

            return new MyDbContext(optionsBuilder.Options);
        }
    }
}
