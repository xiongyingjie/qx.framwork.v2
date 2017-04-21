using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.ViewModels.Demo
{
    public class Form_M
    {
        public object ToModel()
        {
            throw new NotImplementedException();
        }
        public static Form_M ToViewModel(int testInt, string testString,
            DateTime testDateTime, float testFloat,
            double testDouble, char testChar
            )
        {
            return new Form_M()
            {
                TestInt = testInt,
                TestString = testString,
                TestDateTime = testDateTime,
                TestFloat = testFloat,
                TestDouble = testDouble,
                TestChar = testChar,
                _TestReadOnly = "",
                _TestItems = new List<SelectListItem>()
                {
                      new SelectListItem()
                    {
                        Text = "请选择",Value = "0",Selected = true
                    },
                    new SelectListItem()
                    {
                        Text = "男",Value = "1"
                    },
                    new SelectListItem()
                    {
                        Text = "女",Value = "2"
                    }
                },
                _TestContentFile = "10001"//TableId
            };
        }
        [Required]
        [StringLength(10)]
        [Display(Name = "只读")]
        public string _TestReadOnly;

        [Required]
        [Display(Name = "Int")]
        public int TestInt;

        [Required]
        [Display(Name = "String")]
        public string TestString;

        [Required]
        [Display(Name = "Float")]
        public float TestFloat;

        [Required]
        [Display(Name = "Double")]
        public double TestDouble;

        [Required]
        [Display(Name = "Char")]
        public char TestChar;

        [Required]
        [Display(Name = "Char")]
        public string TestDropDown;
        public List<SelectListItem> _TestItems;

        [Required]
        [Display(Name = "DateTime")]
        public DateTime TestDateTime;
        [Required]
        [Display(Name = "富文本")]
        public string TestRichText;

        [Display(Name = "文件上传")]
        public string TestFile;

        [Display(Name = "文件上传（内容系统）")]
        public string _TestContentFile;
    }
}