using Qx.Wechat.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Wechat.LostAndFound.Models;


namespace Web.Areas.WeChat.ViewModels.LostAndFound
{
    public class LostThingNotice_M
    {
        public static LostThingNotice_M ToViewModel(List<LostThingNotice> lostlist,string UserID)
        {
            return new LostThingNotice_M()
            {
                _Lostlist = lostlist,
                _UserID= UserID
            };
        }

        public List<LostThingNotice> _Lostlist { get; set; }

        public static LostThingNotice_M ToViewModel(List<SelectListItem> AddressItem, List<SelectListItem> RewardItem , List<SelectListItem> ThingTypeItem, string UserID)
        {
            return new LostThingNotice_M()
            {
                RewardItem = RewardItem,
                AddressItem = AddressItem,
                _UserID= UserID,
                ThingTypeItem= ThingTypeItem
            };
        }

        public List<SelectListItem> ThingTypeItem { get; set; }

        public List<SelectListItem> RewardItem { get; set; }

        public List<SelectListItem> AddressItem { get; set; }

        public LostThingNotice ToModel()
        {
            return new LostThingNotice()
            {
                LostThingNoticeID = LostThingNoticeID,
                LostThingTitle = LostThingTitle,
                ThingTypeID = ThingTypeID,
                ThingDescribe = ThingDescribe,
                AddrID = AddrID,
                AddrDetails = AddrDetails,
                LostTime = LostTime,
                Contactor = Contactor,
                ContactorPhone = ContactorPhone,
                RewardWayID = RewardWayID,
                Photo = Photo,
                LostDetails = LostDetails,
                CreateTime = CreateTime,
                StateID = StateID,
                UserID = _UserID
            };
        }

        public string RewordName { get; set; }
        public string TypeName { get; set; }
        public string AddrName { get; set; }
        public string StateName { get; set; }

        [StringLength(50)]
        public string LostThingNoticeID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "标题")]
        public string LostThingTitle { get; set; }

        [Required]
        [StringLength(50)]
        public string _UserID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "物品种类")]
        public string ThingTypeID { get; set; }

        [StringLength(10)]
        [Display(Name = "物品详情描述")]
        public string ThingDescribe { get; set; }

        [Display(Name = "丢失时间")]
        public DateTime LostTime { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "丢失地点")]
        public string AddrID { get; set; }

        [StringLength(50)]
        [Display(Name = "详细地址")]
        public string AddrDetails { get; set; }

        [StringLength(50)]
        [Display(Name = "联系人")]
        public string Contactor { get; set; }

        [StringLength(11)]
        [Display(Name = "联系电话")]
        public string ContactorPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string StateID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "酬谢方式")]
        public string RewardWayID { get; set; }

        [StringLength(50)]
        [Display(Name = "丢失详情描述")]
        public string LostDetails { get; set; }

        [StringLength(50)]
        [Display(Name = "图片")]
        public string Photo { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
