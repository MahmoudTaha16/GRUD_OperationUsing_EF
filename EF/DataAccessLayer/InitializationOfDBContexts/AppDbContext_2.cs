using EF.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DataAccessLayer.InitializationOfDBContexts
{
    internal class AppDbContext_2:DbContext
    {
        //this method is to initialize the dbcontext using the dependency injection 
        //it gives us the flexibilty to prevent the code tighting 
        //and it's the way that we follow in asp.net
        public DbSet<Wallet> Wallets { get; set; } = null!;
        public AppDbContext_2(DbContextOptions options) : base(options)
        {
        }
    }

    public class AppDbContext_2_MainClass
    {
        public static void ASMain()
        {
            string? ConnString = new ConfigurationBuilder().AddJsonFile("D:\\Programming\\EF\\EF\\appSettings.json")
                                               .Build().GetSection("ConnString").Value;
            var optionBuilder = new DbContextOptionsBuilder();
            optionBuilder.UseSqlServer(ConnString);

            var options= optionBuilder.Options;

            using (var context=new AppDbContext_2(options))
            {
                foreach (var item in context.Wallets) 
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
