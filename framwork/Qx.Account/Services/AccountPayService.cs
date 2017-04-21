using System;
using Qx.Account.Interfaces;
using Qx.Account.Models;
using Qx.Tools;

namespace Qx.Account.Services
{
  public  class AccountPayService: BaseRepository, IAccountPayService
    {
      public AccountBag CreateAccount(DataContext dataContext, AccountTypeEnum accountType)
        {
     
          return new AccountBag(dataContext, accountType); ;
        }
        public AccountBag CreateAccount(string accountId, AccountTypeEnum accountType)
        {
            return new AccountBag(accountId, accountType); 
        }
        public AccountBag FindAccount(string accoutId)
      {
          var account = Db.account.Find(accoutId);
          if (account == null)
          {
              throw new Exception("不存在该账户："+accoutId);
          }
          return new AccountBag(account);
      }

      public bool DeleteAccount( string accoutId)
      {
            var account = Db.account.Find(accoutId);
            if (account == null)
            {
                throw new Exception("不存在该账户：" + accoutId);
            }
          Db.account.Remove(account);
          return Db.SaveChanges()>0;
      }

      public bool SyncAccount( AccountBag accountBag)
      {
          return Db.SyncAccount(accountBag);
      }

     

      public PayOrderBag CreatePayOrder(AccountBag payer, AccountBag receiver, double payNum,
          PayOrderTypeEnum payOrderType,
          PaymentTypeEnum paymentType)
      {

         return new PayOrderBag( payer, receiver, payOrderType, paymentType, payNum) ;
      }

      public PayOrderBag CreatePayOrder(string payerId, string receiverId, double chargeNum, PayOrderTypeEnum payOrderType,
          PaymentTypeEnum paymentType)
      {
          var payer = FindAccount(payerId);
          var receiver = FindAccount(receiverId);
          if (payer == null)
          {
              throw new Exception("付款方不存在!payerId=>"+ payerId);
          }
            if (receiver == null)
            {
                throw new Exception("收款方不存在!receiverId=>" + receiverId);
            }
            return CreatePayOrder(payer, receiver, chargeNum, payOrderType, paymentType);
      }

      public PayOrderBag FindPayOrder(string payOrderBagId)
      {
            var payOrder = Db.pay_order.Find(payOrderBagId);
            if (payOrder == null)
            {
                throw new Exception("不存在该订单：" + payOrderBagId);
            }
            return new PayOrderBag(payOrder.PO_ID,FindAccount(payOrder.PayerAccID),
                FindAccount(payOrder.ReceiverAccID), ToOrderType(payOrder.PayOrderTypeID), 
                ToPaymentType(payOrder.PaymentTypeID),payOrder.PayNum);
        }

      public bool DeletePayOrder( string payOrderBagId)
      {
            var payOrder = Db.pay_order.Find(payOrderBagId);
            if (payOrder == null)
            {
                throw new Exception("不存在该账户：" + payOrderBagId);
            }
          Db.pay_order.Remove(payOrder);
          return Db.SaveChanges() > 0;
      }

      public bool SyncPayOrder(PayOrderBag payOrderBag)
      {
            return Db.SyncPayOrder(payOrderBag);
        }


        private PaymentTypeEnum ToPaymentType( string paymentTypeId)
        {
            return (PaymentTypeEnum)Enum.Parse(typeof(PaymentTypeEnum), paymentTypeId);
        }
        private PayOrderTypeEnum ToOrderType( string payTypeId)
        {
            return (PayOrderTypeEnum)Enum.Parse(typeof(PayOrderTypeEnum), payTypeId);
        }

       
    }
}
