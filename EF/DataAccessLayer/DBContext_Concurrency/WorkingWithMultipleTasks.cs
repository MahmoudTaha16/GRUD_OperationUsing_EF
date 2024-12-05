using EF.DataAccessLayer.Entities;
using EF.DataAccessLayer.InitializationOfDBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DataAccessLayer.DBContext_Concurrency
{
    internal class WorkingWithMultipleTasks
    {
        //asynchronous tasks
        static AppDbContext_4? context;
        public static void ASMain()
        {
            string? ConnString = new ConfigurationBuilder().AddJsonFile("D:\\Programming\\EF\\EF\\appSettings.json")
                                               .Build().GetSection("ConnString").Value;
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext_4>(options =>
            options.UseSqlServer(ConnString)
            );

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            context = serviceProvider.GetRequiredService<AppDbContext_4>();
          
            Task[] tasks = new[]
            {
                Task.Factory.StartNew(()=>Job1()),
                Task.Factory.StartNew(()=>Job2())
             };
            Task.WaitAll(tasks);
            Task.WhenAll(tasks).ContinueWith(t => Console.WriteLine("Completed Done"));
            Console.ReadKey();

        }
        static async Task Job1()
        {
            context?.Add(new Wallet { Holder = "Mahmoud", Balance = 2000m });
            await context?.SaveChangesAsync()!;
        }
        static async Task Job2()
        {
           context?.Add(new Wallet { Holder = "Mahmoud2", Balance = 2000m });
           await context?.SaveChangesAsync()!;
        }
    }
}
