using Qx.Wechat.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels
{
    public class ReplyImageMsg_M
    {
        public ReplyImageMsg ToModel()
        {
            return new ReplyImageMsg()
            {
                ReplyMsgId=ReplyMsgId,
                //ToUserName =ToUserName,
                //FromUserName =FromUserName,
                //CreateTime =CreateTime,
                //MsgType =MsgType,
                MediaId =MediaId
            };
        }
        public static ReplyImageMsg_M ToViewModel()
        {
            return new ViewModels.ReplyImageMsg_M() { };
        }
        public static ReplyImageMsg_M ToViewModel(ReplyImageMsg model)
        {
            return new ReplyImageMsg_M() {
                ReplyMsgId = model.ReplyMsgId,
            //    ToUserName = model.ToUserName,
            //    FromUserName = model.FromUserName,
            //CreateTime=model.CreateTime,
            //    MsgType =model.MsgType,
                MediaId =model.MediaId};
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
        [Display(Name = "回复消息的内容")]
        public string MediaId { get; set; }
    }
}