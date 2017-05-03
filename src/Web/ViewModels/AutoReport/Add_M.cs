using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModels.AutoReport
{
    public class Add_M
    {
        [Display(Name = "公告id")]
        public string anouncement_id { get; set; }
        [Display(Name = "公告标题")]
        public string title { get; set; }
        [Display(Name = "作者")]
        public string author { get; set; }
        [Display(Name = "公告内容")]
        public string contents { get; set; }
        [Display(Name = "发布时间")]
        public DateTime create_time { get; set; }
      }
}