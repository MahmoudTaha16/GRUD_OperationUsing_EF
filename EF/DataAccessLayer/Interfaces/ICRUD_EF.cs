using EF.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DataAccessLayer.Interfaces
{
    internal interface ICRUD_EF: IDocumentation
    {
         public  bool GetAll(ref List<Wallet> wallets);
         public bool Add(string? holder, decimal balance);
         public int Add_andReturnID__UsingProcedure(string? holder, decimal balance);
         public bool Delete(int RecordId);
         public bool Update(Wallet Record);
         public Wallet GetAtID(int Id);
         public bool IsExist(int Id);
    }
}
