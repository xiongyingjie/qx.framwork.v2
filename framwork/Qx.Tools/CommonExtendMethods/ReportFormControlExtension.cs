using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Tools.Models.Report;

namespace Qx.Tools.CommonExtendMethods
{
    public static class ReportFormControlExtension
    {

        //base
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls, FormControlConfig newControl)
        {
            newControl.id = newControl.id.HasValue() ? newControl.id : DateTime.Now.Random();
            newControl.sequence = controls.Count + 1;
            controls.Add(newControl);
            return controls;
        }
      
        //��ʾ
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls, 
            string lable, string value="", string id="",
            string regex = "", string inputTip = "", string errorTip = "")
        {
            var cfg=new FormControlConfig(lable, id,  value,-1, regex, inputTip, errorTip);
            return Add(controls,cfg);
        }

        //��ť
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls, 
            string lable, FormControlType type, 
            string value = "", string id = "",
            string regex = "", string inputTip = "", string errorTip = "")
        {
           
            var cfg = new FormControlConfig(lable, id, value, type,-1, regex, inputTip, errorTip);
            return Add(controls, cfg);
        }
        //tip
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls, 
            string lable, FormControlType type )
        {
            var value = "";
            var id = "";
            var regex = "";
            var inputTip = "";
            var errorTip = "";
            return Add(controls, lable, type, value, id, regex, inputTip, errorTip);
        }
        //����
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls, 
            string lable, List<DropDownListItem> items, string value = "", string id = "",
            string regex = "", string inputTip = "", string errorTip = "")
        {
           
            var cfg = new FormControlConfig(lable, id, value, items,-1, regex, inputTip, errorTip);
            return Add(controls, cfg);
        }
        //����
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls, 
            string lable, string name, FormControlType type,
            string crossWidth, List<DropDownListItem> items,
            string value = "", string id = "",
            string regex = "", string inputTip = "", string errorTip = "")
        {
            var cfg = new FormControlConfig(lable, id, name, value, type, crossWidth, items,-1,regex,inputTip,errorTip);
            return Add(controls, cfg);
        }
        #region ���� SelectListItem
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls, string lable, List<SelectListItem> items, string value = "", string id = "")
        {
            return Add(controls, lable, items.ToDropDownListItem(), value, id);
        }
        public static List<FormControlConfig> Add(this List<FormControlConfig> controls, string lable, string name, FormControlType type,
            string crossWidth, List<SelectListItem> items, string value = "", string id = "")
        {
            return Add(controls, lable, name, type, crossWidth,items.ToDropDownListItem(), value, id);
        }
        #endregion
    }
}