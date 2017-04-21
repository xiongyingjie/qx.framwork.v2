namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class conlumn_type
    {
        [Key]
        [StringLength(50)]
        public string ColumnTypeID { get; set; }

        [StringLength(50)]
        public string ColumnTypeName { get; set; }
    }
}
