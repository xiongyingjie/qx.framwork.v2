using System;
using System.Collections.Generic;
using xyj.core.Models;
using xyj.core.Models.Report;

namespace xyj.core.Extensions
{
    public static class FormControlExtension
    {

        //base
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls, FormControlConfig newControl)
        {
            newControl.id = newControl.id.HasValue() ? newControl.id : DateTime.Now.Random();
            newControl.sequence = controls.Count + 1;
            controls.Add(newControl);
            return controls;
        }

        //提示
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls,
            string lable, string value = "", string id = "",
            string regex = "", string inputTip = "", string errorTip = "")
        {
            var cfg = new FormControlConfig(lable, id, value, -1, regex, inputTip, errorTip);
            return Add(controls, cfg);
        }

        //按钮
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls,
            string lable, FormControlType type,
            string value = "", string id = "",
            string regex = "", string inputTip = "", string errorTip = "")
        {

            var cfg = new FormControlConfig(lable, id, value, type, -1, regex, inputTip, errorTip);
            return Add(controls, cfg);
        }
        //tip
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls,
            string lable, FormControlType type)
        {
            var value = "";
            var id = "";
            var regex = "";
            var inputTip = "";
            var errorTip = "";
            return Add(controls, lable, type, value, id, regex, inputTip, errorTip);
        }
        //下拉
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls,
            string lable, List<DropDownListItem> items, string value = "", string id = "",
            string regex = "", string inputTip = "", string errorTip = "")
        {

            var cfg = new FormControlConfig(lable, id, value, items, -1, regex, inputTip, errorTip);
            return Add(controls, cfg);
        }
        //其他
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls,
            string lable, string name, FormControlType type,
            string crossWidth, List<DropDownListItem> items,
            string value = "", string id = "",
            string regex = "", string inputTip = "", string errorTip = "")
        {
            var cfg = new FormControlConfig(lable, id, name, value, type, crossWidth, items, -1, regex, inputTip, errorTip);
            return Add(controls, cfg);
        }
        #region 兼容 DropDownListItem
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls, string lable, List<DropDownListItem> items, string value = "", string id = "")
        {
            return Add(controls, lable, items.ToDropDownListItem(), value, id);
        }
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls, string lable, string name, FormControlType type,
            string crossWidth, List<DropDownListItem> items, string value = "", string id = "")
        {
            return Add(controls, lable, name, type, crossWidth, items.ToDropDownListItem(), value, id);
        }
        #endregion
    }
}