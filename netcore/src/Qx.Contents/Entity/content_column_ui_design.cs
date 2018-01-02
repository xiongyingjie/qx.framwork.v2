namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class content_column_ui_design
    {
        [Key]
        [StringLength(50)]
        public string ccud_id { get; set; }

        public int? num { get; set; }

        [StringLength(50)]
        public string tip { get; set; }

        [StringLength(50)]
        public string validators { get; set; }

        [StringLength(50)]
        public string options { get; set; }

        [StringLength(50)]
        public string width { get; set; }

        [StringLength(50)]
        public string height { get; set; }

        public int? vertical { get; set; }

        [StringLength(50)]
        public string folder { get; set; }

        [StringLength(50)]
        public string submitUrl { get; set; }

        [StringLength(50)]
        public string color { get; set; }

        public virtual content_column_design content_column_design { get; set; }
    }
}
