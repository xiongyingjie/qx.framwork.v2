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
    public class FoundThingNotice_M
    {
        public static FoundThingNotice_M ToViewModel(List<FoundThingNotice> foundlist, string UserID)
        {
            return new FoundThingNotice_M()
            {
                foundlist= foundlist,
                UserID= UserID
            };
        }

        public static FoundThingNotice_M ToViewModel(List<SelectListItem> RewardItem, List<SelectListItem> AddressItem, List<SelectListItem> ThingTypeItem, string UserID)
        {
            return new FoundThingNotice_M()
            {
                RewardItem = RewardItem,
                AddressItem = AddressItem,
                ThingTypeItem= ThingTypeItem,
                UserID = UserID
            };
        }

        public List<SelectListItem> ThingTypeItem { get; set; }

        public FoundThingNotice ToModel()
        {
            return new FoundThingNotice()
            {
                UserID = UserID,
                StateID = StateID,
                CreateTime = CreateTime,
                FoundThingID = FoundThingID,
                FoundThingTitle = FoundThingTitle,
                ThingTypeID = ThingTypeID,
                ThingDescribeDetails = ThingDescribeDetails,
                AddrID = AddrID,
                AddrDetails = AddrDetails,
                FoundTime = FoundTime,
                Contactor = Contactor,
                ContactorPhone = ContactorPhone,
                RewardWayID = RewardWayID,
                Photo = Photo,
                FoundDescribeDetail = FoundDescribeDetail
            };
        }
        public List<FoundThingNotice> foundlist { get; set; }
        public List<SelectListItem> AddressItem { get; set; }

        public List<SelectListItem> RewardItem { get; set; }


        public string ThingType { get; set; }
        public string AddrName { get; set; }
        public string StateName { get; set; }
        public string RewordName { get; set; }

        [StringLength(50)]
        public string FoundThingID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "标题")]
        public string FoundThingTitle { get; set; }

        [Required]
        [StringLength(50)]
        public string UserID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "物品种类")]
        public string ThingTypeID { get; set; }

        [StringLength(50)]
        [Display(Name = "物品详细描述")]
        public string ThingDescribeDetails { get; set; }

        [Display(Name = "拾物时间")]
        public DateTime? FoundTime { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "拾物地点")]
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
        [Display(Name = "拾物详情描述")]
        public string FoundDescribeDetail { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
