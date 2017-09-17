using System;
using System.Data.Entity;
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
            System.Object locker = new System.Object();

            lock (locker)
            {   // 同步代码块
                var old =  db.pay_order.Find(payOrderBag.PayOrder.PO_ID);
                if (old != null &&
                    (old.PayStateID == PayStateEnum.Failed.ToString() ||
                      old.PayStateID == PayStateEnum.Finished.ToString()))
                {//同步检查是否 已完成
                    return false;
                }


                if (payOrderBag.IsSuccessful)
                {
                    //写记录
                    var payerLog = new account_record()
                    {
                        AccountRecordID = payOrderBag.PayOrder.PO_ID + "-" + payOrderBag.Payer.Account.AccountID,
                        AccountID = payOrderBag.Payer.Account.AccountID,
                        Amount = payOrderBag.PayOrder.PayNum,
                        Type = "支出",
                        Time = DateTime.Now,
                        AfterPayedBalance = payOrderBag.Payer.Account.Balance,
                        ServiceCharge = 0,
                        Reason = "订单[" + payOrderBag.PayOrder.PO_ID + "]产生的支出" + payOrderBag.PayOrder.PayNum / 100.0 + "元",
                        PO_ID = payOrderBag.PayOrder.PO_ID
                    };
                    var receiverLog = new account_record()
                    {
                        AccountRecordID = payOrderBag.PayOrder.PO_ID + "-" + payOrderBag.Receiver.Account.AccountID,
                        AccountID = payOrderBag.Receiver.Account.AccountID,
                        Amount = payOrderBag.PayOrder.PayNum,
                        Type = "收入",
                        Time = DateTime.Now,
                        AfterPayedBalance = payOrderBag.Receiver.Account.Balance,
                        ServiceCharge = 0,
                        Reason = "订单[" + payOrderBag.PayOrder.PO_ID + "]产生的收入" + payOrderBag.PayOrder.PayNum / 100.0 + "元",
                        PO_ID = payOrderBag.PayOrder.PO_ID
                    };

                    //改为已完成
                    payOrderBag.PayOrder.PayStateID = PayStateEnum.Finished.ToString();
                    db.account_record.Add(payerLog);
                    db.account_record.Add(receiverLog);
                    db.account.AddOrUpdate(payOrderBag.Payer.Account);
                    db.account.AddOrUpdate(payOrderBag.Receiver.Account);
                    db.pay_order.AddOrUpdate(payOrderBag.PayOrder);
                    return db.SaveChanges() > 0;
                }
                db.account.AddOrUpdate(payOrderBag.Payer.Account);
                db.account.AddOrUpdate(payOrderBag.Receiver.Account);
                db.pay_order.AddOrUpdate(payOrderBag.PayOrder);
                return db.SaveChanges() > 0;
            }
           
        }


        
    }
}
