using System;
using Qx.Order.Interfaces;

namespace Qx.Order.Services
{
    public class OrderProvider : IOrderProvider
    {
        private IOrderService _orderService;
        public OrderProvider(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IOrderService Services
        {
            get
            {
                return _orderService;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
