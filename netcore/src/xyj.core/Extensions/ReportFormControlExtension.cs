using System;
using System.Collections.Generic;
using xyj.core.Models;
using xyj.core.Models.Report;

namespace xyj.core.Extensions
{
    public static class ReportFormControlExtension
    {

        //base
        public static List<ReportControlConfig> Add(this List<ReportControlConfig> controls, ReportControlConfig newControl)
        {
            newControl.id = newControl.id.HasValue() ? newControl.id : DateTime.Now.Random();
            newControl.sequence = controls.Count + 1;
            controls.Add(newControl);
            return controls;
        }

        public static List<ReportControlConfig> Add(this List<ReportControlConfig> controls, string lable, string value = "", string id = "")
        {
            var cfg = new ReportControlConfig(lable, id, value, -1);
            return Add(controls, cfg);
        }
        public static List<ReportControlConfig> Add(this List<ReportControlConfig> controls, string lable, FormControlType type, string value = "", string id = "")
        {

            var cfg = new ReportControlConfig(lable, id, value, type, -1);
            return Add(controls, cfg);
        }
        //tip
        public static List<ReportControlConfig> Add(this List<ReportControlConfig> controls, string lable, FormControlType type)
        {
            var value = "";
            var id = "";
            return Add(controls, lable, type, value, id);
        }
        public static List<ReportControlConfig> Add(this List<ReportControlConfig> controls, string lable, List<DropDownListItem> items, string value = "", string id = "")
        {

            var cfg = new ReportControlConfig(lable, id, value, items, -1);
            return Add(controls, cfg);
        }
        public static List<ReportControlConfig> Add(this List<ReportControlConfig> controls, string lable, string name, FormControlType type,
            string crossWidth, List<DropDownListItem> items, string value = "", string id = "")
        {
            var cfg = new ReportControlConfig(lable, id, name, value, type, crossWidth, items, -1);
            return Add(controls, cfg);
        }
        #region ºÊ»› DropDownListItem
        //public static List<ReportControlConfig> Add(this List<ReportControlConfig> controls, string lable, List<DropDownListItem> items, string value = "", string id = "")
        //{
        //    return Add(controls, lable, items.ToDropDownListItem(), value, id);
        //}
        //public static List<ReportControlConfig> Add(this List<ReportControlConfig> controls, string lable, string name, FormControlType type,
        //    string crossWidth, List<DropDownListItem> items, string value = "", string id = "")
        //{
        //    return Add(controls, lable, name, type, crossWidth, items.ToDropDownListItem(), value, id);
        //}
        #endregion
    }
}