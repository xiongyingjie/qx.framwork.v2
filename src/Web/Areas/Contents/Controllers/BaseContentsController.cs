using Web.Controllers.Base;

namespace Web.Areas.Contents.Controllers
{
    public abstract class BaseContentsController : AccountFilterController
    {
        protected void InitReport(string Title, string AddLink, int pageIndex, int perCount, bool showDeafultButton = true, string ExtraParam = "")
        {
            base.InitReport(Title, AddLink, ExtraParam, showDeafultButton, "Qx.Contents");
        }
    }
}