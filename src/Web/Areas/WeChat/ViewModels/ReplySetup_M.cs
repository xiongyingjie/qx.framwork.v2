using Qx.Wechat.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels
{
    public class ReplySetup_M
    {
        public ReplySetup ToModel()
        {
            return new ReplySetup()
            {
                ReplySetupId = ReplySetupId,
                KeyWord = KeyWord,
                ReplyMsgId = ReplyMsgId,
                ReplyTypeId = ReplyTypeId,
            };
        }

        public static ReplySetup_M ToViewModel()
        {
            return new ReplySetup_M() {};
        }

        public static ReplySetup_M ToViewModel(ReplySetup model)
        {
            return new ReplySetup_M()
            {
                ReplySetupId = model.ReplySetupId,
                KeyWord = model.KeyWord,
                ReplyMsgId = model.ReplyMsgId,
                ReplyTypeId = model.ReplyTypeId,
            };
        }

        public string ReplySetupId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "关键字")]
        public string KeyWord { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "回复消息ID")]
        public string ReplyMsgId { get; set; }

        [Required]
        [Display(Name = "回复类型")]
        public string ReplyTypeId { get; set; }
    }
}