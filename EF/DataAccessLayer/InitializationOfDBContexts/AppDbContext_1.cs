using EF.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DataAccessLayer.InitializationOfDBContexts
{
    internal class AppDbContext_1 : DbContext
    {
        //initialize the dbContext using the normal way 
        //its cons : the code tighting
        public DbSet<Wallet> Wallets { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? ConnString = new ConfigurationBuilder().AddJsonFile("D:\\Programming\\EF\\EF\\appSettings.json")
                                                 .Build().GetSection("ConnString").Value;

            optionsBuilder.UseSqlServer(ConnString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
