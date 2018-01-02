using System;
using Qx.Account.Entity;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Account.Models
{
   public class PayOrderBag
    {
        public pay_order PayOrder { get; set; }
        public AccountBag Payer { get; set; }
        public AccountBag Receiver { get; set; }
        public PayOrderBag(pay_order payOrder)
       {
           PayOrder = payOrder;
       }
        public PayOrderBag(AccountBag payer, AccountBag receiver, 
           PayOrderTypeEnum payOrderType, PaymentTypeEnum paymentType,
           double payNum)
        {
            //取2位有效数字
            var money= (int)(payNum*100);

            Payer = payer;
            Receiver = receiver;
            //payer.Expense(payNum);
            //receiver.Charge(payNum);
            PayOrder = new pay_order
            {
                PO_ID =  //DateTime.Now.FormatTime(false)+"-"+
                DateTime.Now.Random(),
                PayerAccID = payer.Account.AccountID,
                ReceiverAccID = receiver.Account.AccountID,
                CreateTime = DateTime.Now,
                PayNum = money,
                PayOrderTypeID = payOrderType.ToString(),
                PaymentTypeID = paymentType.ToString(),
                PayStateID = PayStateEnum.Created.ToString()
            };
        }
        public PayOrderBag(pay_order payOrder, AccountBag payer, AccountBag receiver,
           PayOrderTypeEnum payOrderType, PaymentTypeEnum paymentType,
           int payNum)
        {
          

            Payer = payer;
            Receiver = receiver;
            PayOrder = payOrder;
            //payer.Expense(payNum);
            //receiver.Charge(payNum);
            //PayOrder = new pay_order
            //{
            //    PO_ID = PO_ID,
            //    PayerAccID = payer.Account.AccountID,
            //    ReceiverAccID = receiver.Account.AccountID,
            //    CreateTime = DateTime.Now,
            //    PayNum = payNum,
            //    PayOrderTypeID = payOrderType.ToString(),
            //    PaymentTypeID = paymentType.ToString(),
            //    PayStateID = PayStateEnum.Created.ToString()
            //};
        }

       public PayOrderBag FinishOrder()
       {//手动完成订单
           if (PayOrder.PayStateID == PayStateEnum.Created.ToString())
           {
                PayOrder.AliPayID = "---";
                PayOrder.PayStateID = PayStateEnum.Finished.ToString();
                //扣款
                Payer.Expense(PayOrder.PayNum);
                Receiver.Charge(PayOrder.PayNum);
                return this;
            }
           else
           {
               throw new Exception("手动完成只支持状态为Created的订单");
           }
       }

        public PayOrderBag ToNextState(string alipayId="")
       {
            if (PayOrder.PayStateID == PayStateEnum.Created.ToString())
            {
                if(!alipayId.HasValue())
                { return    this;}
                PayOrder.AliPayID = alipayId;
                PayOrder.PayStateID = PayStateEnum.Pending.ToString();
            }
           else if (PayOrder.PayStateID == PayStateEnum.Pending.ToString())
            {
                PayOrder.PayStateID = PayStateEnum.Successful.ToString();
                //充值订单
                if (PayOrder.PayOrderTypeID == PayOrderTypeEnum.AliPay.ToString())
                {

                    Payer.Expense(PayOrder.PayNum);
                    Receiver.Charge(PayOrder.PayNum);
                }
                else
                {//转账订单
                    Payer.Expense(PayOrder.PayNum);
                    Receiver.Charge(PayOrder.PayNum);
                }
            }
            else if (PayOrder.PayStateID == PayStateEnum.Successful.ToString())
            {
                PayOrder.PayStateID = PayStateEnum.Finished.ToString();
            }
           return this;
       }
     

       public bool IsValid(string alipayId)
        {
          return PayOrder.AliPayID == alipayId&&!IsEnd;
        }
        public bool IsFinished
        {
            get
            {//此时表示接受到通知，且已经将金额写到数据库
                return  PayOrder.PayStateID == PayStateEnum.Finished.ToString();
            }
            
        }
        public bool IsSuccessful
        {//此时表示接受到通知，但是还没做出反应
            get
            {
                return PayOrder.PayStateID == PayStateEnum.Successful.ToString();
            }

        }
        public bool IsEnd
        {//订单终结
            get { return PayOrder.PayStateID == PayStateEnum.Failed.ToString()|| PayOrder.PayStateID == PayStateEnum.Finished.ToString(); }

        }

        public PayOrderBag Failed()
        {
            PayOrder.PayStateID = PayStateEnum.Failed.ToString();
            return this;
        }
    }
}
