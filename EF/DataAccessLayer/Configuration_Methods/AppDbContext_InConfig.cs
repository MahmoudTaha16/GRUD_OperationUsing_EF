using EF.DataAccessLayer.Configuration_Methods;
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
    internal class AppDbContext_InConfig : DbContext
    {

        //this method we use dependency injection
        //we add the service to the services , and give serviceProvider the job to create new instance
    
        public DbSet<Wallet> Wallets { get; set; } = null!;
        public AppDbContext_InConfig(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //first method=> using the assmplly file to get all the confuguration
            //files in the assmebly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Wallet).Assembly);

            //Second method=> make configuration in the same place in this file
            //modelBuilder.Entity<Wallet>().ToTable("Wallets_s");

            //Third method=> Configure configuration files one by one
            //new WalletConfiguration().Configure(modelBuilder.Entity<Wallet>());



            //configure a column
            //modelBuilder.Entity<Wallet>().Property(p => p.Id).HasColumnName("Idd");

        }



    }
    public class AppDbContext_InConfig_MainClass
    {
        public static void ASMain()
        {
            string? ConnString = new ConfigurationBuilder().AddJsonFile("D:\\Programming\\EF\\GRUD_OperationUsing_EF\\EF\\appSettings.json")
                                               .Build().GetSection("ConnString").Value;

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext_InConfig>(options=>
            options.UseSqlServer(ConnString)
            );
          
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using (var context = serviceProvider.GetService<AppDbContext_InConfig>())
            {
                foreach (var item in context!.Wallets)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
