using EF.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DataAccessLayer.InitializationOfDBContexts
{
    internal class AppDbContext_3:DbContext
    {

        //this method we use dependency injection
        //we add the service to the services , and give serviceProvider the job to create new instance
    
        public DbSet<Wallet> Wallets { get; set; } = null!;
        public AppDbContext_3(DbContextOptions options) : base(options)
        {
        }
    }
    public class AppDbContext_3_MainClass
    {
        public static void ASMain()
        {
            string? ConnString = new ConfigurationBuilder().AddJsonFile("D:\\Programming\\EF\\EF\\appSettings.json")
                                               .Build().GetSection("ConnString").Value;

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext_3>(options=>
            options.UseSqlServer(ConnString)
            );
          
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using (var context = serviceProvider.GetService<AppDbContext_3>())
            {
                foreach (var item in context!.Wallets)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
