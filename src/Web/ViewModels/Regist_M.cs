using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class Regist_M
    {
        [Display(Name = "登录名")]
        [Required]
        [StringLength(10)]
        public string UserId;

        [Display(Name = "昵称")]
        [Required]
        [StringLength(20)]
        public string NickName;

        [Display(Name = "密码")]
        [Required]
        [StringLength(20)]
        public string UserPsw;

        [Display(Name = "重复密码")]
        [Required]
        [StringLength(20)]
        public string UserPsw2;

        [Display(Name = "已同意注册条款")]
        [Required]
        [StringLength(20)]
        public bool Agreen;

        [Display(Name = "手机(可选)")]
        [StringLength(20)]
        public string Phone;

        [Display(Name = "邮箱(可选)")]     
        [StringLength(50)]
        public string Email;
    }
}