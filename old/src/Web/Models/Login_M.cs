using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Login_M
    {
        [Required]
        [StringLength(10)]
        [Display(Name = "登录名")]
        public string UserId;
        [Required]
        [StringLength(20)]
        [Display(Name = "密码")]
        public string UserPsw;
        [Display(Name = "App下载地址")]
        public string AppUrl;
        [Display(Name = "App二维码地址")]
        public string AppPicUrl;
        [Display(Name = "微信二维码地址")]
        public string WeiXinPicUrl;
        
    }
}