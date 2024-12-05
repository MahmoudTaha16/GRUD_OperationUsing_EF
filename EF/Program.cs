using EF.DataAccessLayer.DBContext_Concurrency;
using EF.DataAccessLayer.Entities;
using EF.DataAccessLayer.InitializationOfDBContexts;

namespace EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Wallet wallet = new Wallet();
            //List<Wallet> wallets = new List<Wallet>();

            //wallet.GetAtID(3);
            ////wallet.GetAll(ref wallets);
            ////wallet.Print(wallets);
            //wallet.Print(new List<Wallet>() { wallet.GetAtID(3) });




            WorkingWithMultipleTasks.ASMain();

            Console.WriteLine("Hello, World!");
        }
    }
}
