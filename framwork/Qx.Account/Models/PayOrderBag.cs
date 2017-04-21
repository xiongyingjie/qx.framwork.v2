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
                PO_ID =  DateTime.Now.Random().ToString(),
                PayerAccID = payer.Account.AccountID,
                ReceiverAccID = receiver.Account.AccountID,
                CreateTime = DateTime.Now,
                PayNum = money,
                PayOrderTypeID = payOrderType.ToString(),
                PaymentTypeID = paymentType.ToString(),
                PayStateID = PayStateEnum.Created.ToString()
            };
        }
        public PayOrderBag(string PO_ID,AccountBag payer, AccountBag receiver,
           PayOrderTypeEnum payOrderType, PaymentTypeEnum paymentType,
           int payNum)
        {
          

            Payer = payer;
            Receiver = receiver;
            //payer.Expense(payNum);
            //receiver.Charge(payNum);
            PayOrder = new pay_order
            {
                PO_ID = PO_ID,
                PayerAccID = payer.Account.AccountID,
                ReceiverAccID = receiver.Account.AccountID,
                CreateTime = DateTime.Now,
                PayNum = payNum,
                PayOrderTypeID = payOrderType.ToString(),
                PaymentTypeID = paymentType.ToString(),
                PayStateID = PayStateEnum.Created.ToString()
            };
        }


        private PayOrderBag ChangeState(PayStateEnum state)
       {
            PayOrder.PayStateID = state.ToString();
           return this;
       }
        public PayOrderBag Pending(string alipayId)
        {
            //如果是Created才处理
            if (PayOrder.PayStateID == PayStateEnum.Created.ToString())
            {
                var payOrder = ChangeState(PayStateEnum.Pending);
                payOrder.PayOrder.AliPayID = alipayId;
                return payOrder;
            }
            else
            {
                return this;
            }
         
        }
        public bool IsValid(string alipayId)
        {
          return PayOrder.AliPayID == alipayId;
        }
        public bool IsFinished
        {
            get
            {
                return PayOrder.PayStateID == PayStateEnum.Successful.ToString() || PayOrder.PayStateID == PayStateEnum.Finished.ToString();
            }
            
        }
        public PayOrderBag Successful()
       {
            //充值订单
            if (PayOrder.PayOrderTypeID == PayOrderTypeEnum.AliPay.ToString())
            {

                Payer.Expense(PayOrder.PayNum);
                Receiver.Charge(PayOrder.PayNum);
            }
            else
            {
                Payer.Expense(PayOrder.PayNum);
                Receiver.Charge(PayOrder.PayNum);
            }
            //转账订单
        
            return ChangeState(PayStateEnum.Successful);
       }
        public PayOrderBag Finished()
        {

            return ChangeState(PayStateEnum.Finished);
        }
        public PayOrderBag Failed()
        {
            //如果不是Finished或Successful才处理
            if (PayOrder.PayStateID == PayStateEnum.Finished.ToString()|| 
                PayOrder.PayStateID == PayStateEnum.Successful.ToString())
            {
                return ChangeState(PayStateEnum.Failed);
            }else
            {
                return this;
            }
               
        }
    }
}
