using Qx.Account.Models;
using Qx.Tools;
using Qx.Tools.Interfaces;

namespace Qx.Account.Interfaces
{
  public  interface IAccountPayService: IAutoInject
    {
        AccountBag CreateAccount(DataContext dataContext, AccountTypeEnum accountType);
        AccountBag CreateAccount(string  accId, AccountTypeEnum accountType);
        AccountBag FindAccount(string accoutId);
        bool DeleteAccount( string accoutId);
        bool SyncAccount( AccountBag accountBag);

      PayOrderBag CreatePayOrder( AccountBag payer, AccountBag receiver, double payNum,
          PayOrderTypeEnum payOrderType, PaymentTypeEnum paymentType
         );
        PayOrderBag CreatePayOrder(string payerId, string receiverId, double chargeNum,
         PayOrderTypeEnum payOrderType, PaymentTypeEnum paymentType
        );
        PayOrderBag FindPayOrder(string payOrderBagId);
        bool DeletePayOrder(string payOrderBagId);
        bool SyncPayOrder(PayOrderBag payOrderBag);

    }
}
