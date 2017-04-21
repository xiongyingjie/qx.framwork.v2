using Qx.Wechat.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels
{
    public class ReplyTextMsg_M
    {
        public ReplyTextMsg ToModel()
        {
            return new ReplyTextMsg()
            {
                ReplyMsgId =ReplyMsgId,
                //ToUserName =ToUserName,
                //FromUserName =FromUserName,
                //CreateTime =CreateTime,
                //MsgType=MsgType,Content=Content
            };
        }
        public static ReplyTextMsg_M ToViewModel()
        {
            return new ReplyTextMsg_M() { };
        }
        public static ReplyTextMsg_M ToViewModel(ReplyTextMsg model)
        {
            return new ReplyTextMsg_M()
            {
                ReplyMsgId =model.ReplyMsgId,
                //ToUserName =model.ToUserName,
                //FromUserName =model.FromUserName,
                //CreateTime=model.CreateTime,
                //MsgType =model.MsgType,
                Content =model.Content
            }; 
        }
        public string ReplyMsgId { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "发送人")]
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

        [StringLength(10)]
        [Display(Name = "消息内容")]
        public string Content { get; set; }
    }
}