using Qx.Wechat.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels
{
    public class NewsMsgItem_M
    {
        public NewsMsgItem ToModel()
        {
            return new NewsMsgItem()
            {
                NewsMsgItemId= NewsMsgItemId,
                ReplyMsgId =ReplyMsgId ,
                Title = Title,
                Description = Description,
                PicUrl = PicUrl,
                Url = Url
            };
        }
        public static NewsMsgItem_M ToViewModel()
        {
            return new NewsMsgItem_M() { };
        }
        public static NewsMsgItem_M ToViewModel(NewsMsgItem model)
        {
            return new NewsMsgItem_M()
            {
                NewsMsgItemId= model.NewsMsgItemId,
                ReplyMsgId = model.ReplyMsgId,
                Title = model.Title,
                Description = model.Description,
                PicUrl = model.PicUrl,
                Url = model.Url
            };
        }

        public string NewsMsgItemId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "接收人")]
        public string  ReplyMsgId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "图文标题")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "图文描述")]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "图文链接")]
        public string PicUrl { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "图文跳转链接")]
        public  string Url { get; set; }
    }
}