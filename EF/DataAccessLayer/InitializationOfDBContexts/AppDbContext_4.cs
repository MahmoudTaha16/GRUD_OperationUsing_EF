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
    internal class AppDbContext_4:DbContext
    {
        //this method is to initialize the dbcontext using the factory design pattern 
        //it uses the context factory
        public DbSet<Wallet> Wallets { get; set; } = null!;
        public AppDbContext_4(DbContextOptions options) : base(options)
        {
        }
    }
    public class AppDbContext_4_MainClass
    {
        public static void ASMain()
        {
            string? ConnString = new ConfigurationBuilder().AddJsonFile("D:\\Programming\\EF\\EF\\appSettings.json")
                                               .Build().GetSection("ConnString").Value;
            var services = new ServiceCollection();
            services.AddDbContextFactory<AppDbContext_4>(options =>
            options.UseSqlServer(ConnString)
            );

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var dbContextFactory = serviceProvider.GetService<IDbContextFactory<AppDbContext_4>>();
            using (var context = dbContextFactory!.CreateDbContext())
            {
                foreach (var item in context!.Wallets)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
