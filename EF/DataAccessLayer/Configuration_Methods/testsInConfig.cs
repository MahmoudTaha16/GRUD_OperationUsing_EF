using EF.DataAccessLayer.InitializationOfDBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DataAccessLayer.Configuration_Methods
{
    internal class testsInConfig
    {

        public static void mm()
        {

            string? ConnString = new ConfigurationBuilder().AddJsonFile("D:\\Programming\\EF\\EF\\appSettings.json")
                                              .Build().GetSection("ConnString").Value;
            var optionBuilder = new DbContextOptionsBuilder();
            optionBuilder.UseSqlServer(ConnString);

            var options = optionBuilder.Options;

            using (var context = new AppDbContext_InConfig(options))
            {
                foreach (var item in context.Wallets)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
