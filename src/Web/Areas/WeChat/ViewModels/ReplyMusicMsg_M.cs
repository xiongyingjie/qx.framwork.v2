using Qx.Wechat.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels
{
    public class ReplyMusicMsg_M
    {
        public ReplyMusicMsg ToModel()
        {
            return new ReplyMusicMsg()
            {
                ReplyMsgId =ReplyMsgId,
            //    ToUserName =ToUserName,
            //    FromUserName =FromUserName,
            //    CreateTime =CreateTime,
            //MsgType=MsgType,
                Title =Title,
                MusicURL =MusicURL,
                Description =Description,
                HQMusicUrl =HQMusicUrl,
                ThumbMediaId =ThumbMediaId};
        }
        public static ReplyMusicMsg_M ToViewModel()
        {
            return new ReplyMusicMsg_M() { };
        }
        public static ReplyMusicMsg_M ToViewModel(ReplyMusicMsg model)
        {
            return new ReplyMusicMsg_M()
            {
                ReplyMsgId = model.ReplyMsgId,
            //    ToUserName = model.ToUserName,
            //    FromUserName = model.FromUserName,
            //CreateTime=model.CreateTime,
            //    MsgType =model.MsgType,
                Title =model.Title,
                MusicURL =model.MusicURL,
                Description =model.Description,
            HQMusicUrl=model.HQMusicUrl,
                ThumbMediaId =model.ThumbMediaId
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
        [Display(Name = "音乐标题")]
        public string Title { get; set; }

        [StringLength(10)]
        [Display(Name = "音乐描述")]
        public string Description { get; set; }

        [StringLength(10)]
        [Display(Name = "音乐链接")]
        public string MusicURL { get; set; }

        [StringLength(10)]
        [Display(Name = "高质量音乐链接")]
        public string HQMusicUrl { get; set; }

        [StringLength(10)]
        [Display(Name = "缩略图的媒体ID")]
        public string ThumbMediaId { get; set; }
    }

}