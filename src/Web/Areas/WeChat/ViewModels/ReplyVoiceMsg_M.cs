using Qx.Wechat.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels
{
    public class ReplyVoiceMsg_M
    {
        public ReplyVoiceMsg ToModel()
        {
            return new ReplyVoiceMsg()
            {
                ReplyMsgId =ReplyMsgId,
                //ToUserName =ToUserName,
                //FromUserName =FromUserName,
                //CreateTime =CreateTime,
                //MsgType=MsgType,
                MediaId =MediaId
            };
        }
        public static ReplyVoiceMsg_M ToViewModel()
        {
            return new ReplyVoiceMsg_M() { };
        }
        public static ReplyVoiceMsg_M ToViewModel(ReplyVoiceMsg model)
        {
            return new ReplyVoiceMsg_M()
            {
                ReplyMsgId =model.ReplyMsgId,
                //ToUserName =model.ToUserName,
                //FromUserName =model.FromUserName,
                //CreateTime=model.CreateTime,
                //MsgType =model.MsgType,
                MediaId =model.MediaId
            };
        }
        public string ReplyMsgId { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="接收人")]
        public string ToUserName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "发送人")]
        public string FromUserName { get; set; }

        [Display(Name = "消息创建时间")]
        public string CreateTime { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "消息类型")]
        public string MsgType { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "媒体ID")]
        public string MediaId { get; set; }
    }
}