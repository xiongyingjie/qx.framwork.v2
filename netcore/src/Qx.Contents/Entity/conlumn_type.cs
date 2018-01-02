namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class conlumn_type
    {
        [Key]
        [StringLength(50)]
        public string column_type_id { get; set; }

        [StringLength(50)]
        public string column_type_name { get; set; }
    }
}
