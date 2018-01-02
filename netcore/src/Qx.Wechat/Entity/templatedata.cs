namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("templatedata")]
    public partial class templatedata
    {
        [StringLength(50)]
        public string TemplatedataID { get; set; }

        [StringLength(50)]
        public string TemplateID { get; set; }

        public int? Sequence { get; set; }

        [StringLength(50)]
        public string Value { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public virtual template template { get; set; }
    }
}
