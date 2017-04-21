using Qx.Wechat.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels
{
    public class ReplyVideoMsg_M
    {
        public ReplyVideoMsg ToModel()
        {
            return new ReplyVideoMsg()
            {
                ReplyMsgId =ReplyMsgId,
                //ToUserName =ToUserName,
                //FromUserName =FromUserName,
                //CreateTime =CreateTime,
                //MsgType=MsgType,
                MediaId =MediaId,
                Title =Title,
                Description =Description
            };
        }
        public static ReplyVideoMsg_M ToViewModel()
        {
            return new ReplyVideoMsg_M() { };
        }
        public static ReplyVideoMsg_M ToViewModel(ReplyVideoMsg model)
        {
            return new ReplyVideoMsg_M()
            {
                ReplyMsgId =model.ReplyMsgId,
                //ToUserName =model.ToUserName,
                //FromUserName =model.FromUserName,
                //CreateTime =model.CreateTime,
                //MsgType=model.MsgType,
                MediaId =model.MediaId,
                Title =model.Title,
                Description =model.Description
            };
        }
        public string ReplyMsgId { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="发送人")]
        public string ToUserName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "接收人")]
        public string FromUserName { get; set; }

        [Display(Name = "消息创建时间")]
        public string CreateTime { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "消息类型")]
        public string MsgType { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "视频ID")]
        public string MediaId { get; set; }

        [StringLength(10)]
        [Display(Name = "视频的标题")]
        public string Title { get; set; }

        [StringLength(10)]
        [Display(Name = "视频的描述")]
        public string Description { get; set; }
    }
}