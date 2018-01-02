namespace Qx.Msg.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sms_send_record
    {
        [Key]
        [StringLength(50)]
        public string RequestId { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string SignName { get; set; }

        [Required]
        [StringLength(50)]
        public string TemplateCode { get; set; }

        [Required]
        [StringLength(50)]
        public string ParamString { get; set; }

        public DateTime SendTime { get; set; }

        public DateTime ExpiredTime { get; set; }

        public int Verified { get; set; }

        public int CheckCount { get; set; }

        [StringLength(50)]
        public string Sender { get; set; }

        [StringLength(50)]
        public string ErrorMessage { get; set; }
    }
}
