using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.SmsSendRecord
{
    public class SmsSendRecord_M
    {
        public sms_send_record ToModel()
        {
            return new sms_send_record()
            {
                RequestId = RequestId,
                Code = Code,
                PhoneNumber = PhoneNumber,
                SignName = SignName,
                TemplateCode = TemplateCode,
                ParamString = ParamString,
                SendTime = SendTime,
                ExpiredTime = ExpiredTime,
                Verified = Verified,
                CheckCount = CheckCount,
                Sender = Sender,
                ErrorMessage = ErrorMessage

            };
        }
        public static SmsSendRecord_M ToModel(sms_send_record smssendrecord)
        {
            return new SmsSendRecord_M()
            {
                RequestId = smssendrecord.RequestId,
                Code = smssendrecord.Code,
                PhoneNumber = smssendrecord.PhoneNumber,
                SignName = smssendrecord.SignName,
                TemplateCode = smssendrecord.TemplateCode,
                ParamString = smssendrecord.ParamString,
                SendTime = smssendrecord.SendTime,
                ExpiredTime = smssendrecord.ExpiredTime,
                Verified = smssendrecord.Verified,
                CheckCount = smssendrecord.CheckCount,
                Sender = smssendrecord.Sender,
                ErrorMessage = smssendrecord.ErrorMessage
            };
        }
        [Display(Name = "请求ID")]
        [StringLength(50)]
        public string RequestId { get; set; }

        [Display(Name = "密码")]
        [StringLength(50)]
        public string Code { get; set; }

        [Display(Name = "电话")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Display(Name = "服务类型")]
        [StringLength(50)]
        public string SignName { get; set; }

        [Display(Name = "模板代码")]
        [StringLength(50)]
        public string TemplateCode { get; set; }

        [Display(Name = "ParamString")]
        [StringLength(50)]
        public string ParamString { get; set; }

        [Display(Name = "发送时间")]
        [Column(TypeName = "datetime2")]
        public DateTime SendTime { get; set; }

        [Display(Name = "过期时间")]
        [Column(TypeName = "datetime2")]
        public DateTime ExpiredTime { get ; set; }

        [Display(Name = "Verified")]
        public int Verified { get; set; }

        [Display(Name = "CheckCount")]
        public int CheckCount { get; set; }

        [Display(Name = "发送者")]
        [StringLength(50)]
        public string Sender { get; set; }

        [Display(Name = "错误消息")]
        [StringLength(50)]
        public string ErrorMessage { get; set; }
    }
}