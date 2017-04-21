using System;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Account.Models
{
   public class AccountBag
    {
        public AccountBag(Entity.account account)
       {
           Account = account;
       }
        public AccountBag(string accountId, AccountTypeEnum accountType)
        {
            // AccountType = accountType;
            Account = new Entity.account
            {
                AccountID = accountId,
                Balance = 0,
                LastUpdateTime = DateTime.Now,
                AccType = accountType.ToString()
            };
        }
        public AccountBag (DataContext dataContext,  AccountTypeEnum accountType)
        {
           // AccountType = accountType;
            Account = new Entity.account
            {
                AccountID = dataContext.UserID + DateTime.Now.Random().ToString(),
                Balance = 0,
                LastUpdateTime = DateTime.Now,
                AccType = accountType.ToString()
            };
        }
     
        public Entity.account Account { get; set; }
        public AccountBag Charge(int num)
        {
          
            Account.Balance+= num;
            Account.LastUpdateTime = DateTime.Now;
            return this;
        }

        public AccountBag Expense(int num)
        {
            //if (Account.Balance <= 0)
            //{
            //    throw new Exception("警告:不允许账户透支！正在尝试透支的账户为:"+Account.AccountID);
            //}
            Account.Balance -= num;
            Account.LastUpdateTime=DateTime.Now;
            return this;
        }
        public AccountBag ChangeType(AccountTypeEnum type)
        {
            Account.AccType  = type.ToString();
            return this;
        }
    }
}
