using EF.DataAccessLayer.Attributes;
using EF.DataAccessLayer.InitializationOfDBContexts;
using EF.DataAccessLayer.Interfaces;
using System.Text;

namespace EF.DataAccessLayer.Entities
{
    public class Wallet:ICRUD_EF
    {
        public virtual int Id { get; set; }
        public virtual string Holder { get; set; } = null!;
        public virtual decimal Balance { get; set; }

        public override string ToString()
        {
            return $"[{Id}]  {Holder}   ({Balance:C})";
        }

        [Description("Add a record to the data Base and save the changes")]
        public bool Add(string? holder, decimal balance)
        {
            #region
            Wallet? wallet = new Wallet
            {
                Holder = holder!,
                Balance = balance
            };
            bool result = false; ;
            using (var context = new AppDbContext_1())
            {

                context.Wallets.Add(wallet);
                context.SaveChanges();
                result = true; ;
            }

            return result;
            #endregion
        }
        [Description("Add a record to the data Base , save the changes,and return the Id")]
        public int Add_andReturnID__UsingProcedure(string? holder, decimal balance)
        {
            #region
            Wallet? wallet = new Wallet
            {
                Holder = holder!,
                Balance = balance
            };
            int Id = -1;
            using (var context = new AppDbContext_1())
            {

                context.Wallets.Add(wallet);
                Id = context.Wallets.Last().Id;
                context.SaveChanges();
            }

            return Id;
            #endregion
        }
        [Description("Delete a record from the data Base and save the changes")]
        public bool Delete(int RecordId)
        {
            #region
            bool result = false;
            using (var context = new AppDbContext_1())
            {
                Wallet wallet = context.Wallets.FirstOrDefault(x => x.Id == RecordId)!;
                context.Wallets.Remove(wallet);
                context.SaveChanges();
                result = true; ;
            }
            return result;
            #endregion
        }



        [Description("Get all records from the data Base")]
        public bool GetAll(ref List<Wallet> wallets)
        {
            #region
            bool result = false; ;
            using (var context = new AppDbContext_1())
            {
                wallets = context.Wallets.ToList();
                result = true;
            }
            return result;
            #endregion

        }
        [Description("Get a record at Id from the data Base")]
        public Wallet GetAtID(int Id)
        {
            #region
            Wallet? wallet = null;
            using (var context = new AppDbContext_1())
            {
                wallet = context.Wallets.FirstOrDefault(x => x.Id == Id)!;
            }
            return wallet;
            #endregion
        }

        [Description("Check if a record is exist in the data Base")]
        public bool IsExist(int Id)
        {
            #region
            Wallet? wallet = null;
            using (var context = new AppDbContext_1())
            {
                wallet = context.Wallets.FirstOrDefault(x => x.Id == Id)!;
            }

            return wallet is not null;
            #endregion
        }
        [Description("Update a record info in the data Base")]
        public bool Update(Wallet Record)
        {
            #region
            Wallet? wallet = null;
            bool result = false; ;
            using (var context = new AppDbContext_1())
            {
                wallet = context.Wallets.FirstOrDefault(x => x.Id == Record.Id)!;

                wallet.Holder = Record.Holder;
                wallet.Balance = Record.Balance;
                context.SaveChanges();
                result = true; ;
            }

            return result;
            #endregion
        }


        [Description("This method is used to (Document) descripe the usage of the mathods")]
        public string Document()
        {
            #region
            StringBuilder stringBuilder = new StringBuilder();
            Type ObjectType = typeof(Wallet);

            if (ObjectType != null)
            {
                var methods = ObjectType.GetMethods();
                //Console.WriteLine( $"{methods.Length}" );
                foreach (var item in methods)
                {
                    //string description = String.Join(" , ", item.GetParameters().Select(x => x.ParameterType.ToString() + x.Name).ToList());
                    string description = "";
                    foreach (var attr in item.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>())
                    {
                        description = attr.Description;
                    }
                    if (description == "") continue;
                    string privateorPublic = item.IsPrivate ? "Private" : "Public";
                    stringBuilder.AppendLine(
                        $"{description} \n {privateorPublic} {item.ReturnType}   {item.Name} " +
                         $"( {string.Join(" , ", item.GetParameters().Select(x => x.ParameterType.ToString() + "  " + x.Name).ToList())})"
                        );

                    stringBuilder.AppendLine();
                }
            }
            return stringBuilder.ToString();
            #endregion
        }

        public void Print(List<Wallet> wallets)
        {
            foreach (var item in wallets)
            {
                Console.WriteLine( item );
            }
        }

    }
}
