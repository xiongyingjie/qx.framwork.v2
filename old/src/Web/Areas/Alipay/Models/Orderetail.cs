using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Alipay.Models
{
    public class Orderetail
    {
        [Display(Name = "商户订单号")]
        public string WIDout_trade_no { get; set; }
        [Display(Name = "商品名称")]
        public string WIDsubject { get; set; }
        [Display(Name = "付款金额")]
        public double WIDtotal_fee { get; set; }
        [Display(Name = "商品描述")]
        public string WIDbody { get; set; }
       
    }
}