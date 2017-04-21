namespace Web.Areas.Permission.ViewModels.Admin
{
    public class ButtonList_M
    {
        public static ButtonList_M ToViewModel(string buttonid)
        {
            return new ButtonList_M() { buttonid = buttonid };
        }
        public string buttonid;
    }
}