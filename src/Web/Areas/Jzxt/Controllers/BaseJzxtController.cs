using Web.Controllers.Base;

namespace Web.Areas.Jzxt.Controllers
{
    public class BaseJzxtController : BaseController
    {
        protected void InitReport(string Title, string AddLink, bool showDeafultButton = true, string ExtraParam = "")
        {
            base.InitReport(Title, AddLink, ExtraParam, showDeafultButton, "Qx.Bysj.Jzxt");
        }
    }
}