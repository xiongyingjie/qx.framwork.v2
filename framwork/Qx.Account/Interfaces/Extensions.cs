﻿using System;
using System.Data.Entity.Migrations;
using Qx.Account.Entity;
using Qx.Account.Models;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Account.Interfaces
{
  public static  class Extensions
    {
      public static bool SyncAccount(this MyDbContext db, AccountBag accountBag)
      {
            db.account.AddOrUpdate(accountBag.Account);
            return db.SaveChanges() > 0;
        }
        public static bool SyncPayOrder(this MyDbContext db, PayOrderBag payOrderBag)
        {
            #region 构造log (仅状态完成时产生)

            if (payOrderBag.IsFinished)
            {
                var payerLog = new account_record()
                {
                    AccountRecordID = payOrderBag.Payer.Account.AccountID + DateTime.Now.Random(),
                    AccountID = payOrderBag.Payer.Account.AccountID,
                    Amount = payOrderBag.PayOrder.PayNum,
                    Type = "支出",
                    Time = DateTime.Now,
                    AfterPayedBalance = payOrderBag.Payer.Account.Balance,
                    ServiceCharge = 0,
                    Reason = "订单[" + payOrderBag.PayOrder.PO_ID + "]产生的支出" + payOrderBag.PayOrder.PayNum / 100.0+"元",
                    PO_ID = payOrderBag.PayOrder.PO_ID
                };
                var receiverLog = new account_record()
                {
                    AccountRecordID = payOrderBag.Receiver.Account.AccountID + DateTime.Now.Random(),
                    AccountID = payOrderBag.Receiver.Account.AccountID,
                    Amount = payOrderBag.PayOrder.PayNum,
                    Type = "收入",
                    Time = DateTime.Now,
                    AfterPayedBalance = payOrderBag.Receiver.Account.Balance,
                    ServiceCharge = 0,
                    Reason = "订单[" + payOrderBag.PayOrder.PO_ID + "]产生的收入" + payOrderBag.PayOrder.PayNum / 100.0 + "元",
                    PO_ID = payOrderBag.PayOrder.PO_ID
                };
                db.account_record.AddOrUpdate(payerLog);
                db.account_record.AddOrUpdate(receiverLog);
            }
            
            #endregion
            db.account.AddOrUpdate(payOrderBag.Payer.Account);
            db.account.AddOrUpdate(payOrderBag.Receiver.Account);
            db.pay_order.AddOrUpdate(payOrderBag.PayOrder);
            return db.SaveChanges() > 0;
        }


        
    }
}
