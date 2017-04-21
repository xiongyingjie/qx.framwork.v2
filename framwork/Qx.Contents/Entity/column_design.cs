namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class column_design
    {
        [Key]
        [StringLength(50)]
        public string ColumnDesignID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int ShowCount { get; set; }

        [Required]
        [StringLength(20)]
        public string UnitID { get; set; }

        [StringLength(50)]
        public string UpdateTypeID { get; set; }

        [Column(TypeName = "text")]
        public string HtmlTemplate { get; set; }

        [StringLength(500)]
        public string HtmlTemplateParams { get; set; }

        [StringLength(50)]
        public string LibraryID { get; set; }
    }
}
