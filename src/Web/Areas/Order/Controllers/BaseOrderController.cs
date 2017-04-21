using Qx.Tools.Interfaces;
using Web.Controllers.Base;

namespace Web.Areas.Order.Controllers
{
    public abstract class BaseOrderController : AccountFilterController
    {
        protected void InitReport(string Title, string AddLink, int pageIndex, int perCount, bool showDeafultButton = true, string ExtraParam = "")
        {
            base.InitReport(Title, AddLink,ExtraParam, showDeafultButton, "Djk.Order");
        }
        protected IProductProvider ProductProvider
        {
            get
            {
                return null;
            }
        }
    }
}