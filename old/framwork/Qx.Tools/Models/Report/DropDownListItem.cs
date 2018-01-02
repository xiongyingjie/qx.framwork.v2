using System.Web.Mvc;

namespace Qx.Tools.Models.Report
{
    public class DropDownListItem:SelectListItem
    {
        //
        // 摘要:
        //     Gets or sets a value that indicates whether this System.Web.Mvc.SelectListItem
        //     is selected.
        //
        // 返回结果:
        //     true if the item is selected; otherwise, false.
        public bool selected
        {
            get
            {
                return Selected;
            }
        }

        //
        // 摘要:
        //     Gets or sets the text of the selected item.
        //
        // 返回结果:
        //     The text.
        public string text
        {
            get
            {
                return Text;
            }
        }
        //
        // 摘要:
        //     Gets or sets the value of the selected item.
        //
        // 返回结果:
        //     The value.
        public string value
        {
            get
            {
                return Value;
            }
        }
    }
}