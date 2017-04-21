using System.Web.Mvc;

namespace Web.Areas.Msg
{
    public class MsgAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Msg";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Msg_default",
                "Msg/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}