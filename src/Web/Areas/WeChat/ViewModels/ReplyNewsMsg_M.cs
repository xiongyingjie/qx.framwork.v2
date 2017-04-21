using Qx.Wechat.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels
{
    public class ReplyNewsMsg_M
    {
        public ReplyNewsMsg ToModel()
        {
            return new ReplyNewsMsg()
            {
                ReplyMsgId=ReplyMsgId,
                //ToUserName =ToUserName,
                //FromUserName =FromUserName,
                //CreateTime =CreateTime,
                //MsgType =MsgType,
                ArticleCount =ArticleCount
            };
        }
        public static ReplyNewsMsg_M ToViewModel()
        {
            return new ReplyNewsMsg_M() { };
        }
        public static ReplyNewsMsg_M ToViewModel(ReplyNewsMsg model)
        {
            return new ReplyNewsMsg_M()
            {
                ReplyMsgId =model.ReplyMsgId,
                //ToUserName =model.ToUserName,
                //FromUserName =model.FromUserName,
                //CreateTime =model.CreateTime,
                //MsgType=model.MsgType,
                ArticleCount =model.ArticleCount};
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

        [Display(Name = "图文消息个数")]
        public int ArticleCount { get; set; }
    }
}