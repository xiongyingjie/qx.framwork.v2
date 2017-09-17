using Qx.Tools.Interfaces;

namespace Qx.Order.Interfaces
{
    public interface IOrderProvider : IAutoInject
    {
        IOrderService Services { get; set; }
    }
}
