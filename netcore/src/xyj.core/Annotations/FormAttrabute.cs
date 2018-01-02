using System;
using xyj.core.Models;

namespace xyj.core.Annotations
{
    [AttributeUsage(AttributeTargets.All)]
    public class Form : Attribute
    {
        public string Lable;
        public Show Show;
        public FormControlType  ControlType;
        public Form()
        {
            this.Show = Show.None;
            this.ControlType = FormControlType.Input;
        }
        public Form(string lable,Show show, FormControlType controlType)
        {
            Lable = lable;
            Show = show;
            ControlType = controlType;
        }
    }

    public enum Show
    {
        None=0,
        Add=1,
        Edit=2, 
        AddEdit=3,
        AddEditReadOnly = 4,
        Search =5,
        AddSearch=6,
        EditSearch=7,
        AddEditSearch = 8
    }
    //public enum Control
    //{
    //    Input = 1,
    //    DateTime = 2,
    //    Date = 3,
    //    DropDownList = 4,
    //    Radio = 5,
    //    Editor = 6,
    //    CheckBox = 7,
    //    Switch = 8,
    //    TextArea = 9,
    //    File=10
    //}
}
