namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("library")]
    public partial class library
    {
        [StringLength(50)]
        public string LibraryID { get; set; }

        [Required]
        [StringLength(50)]
        public string FatherID { get; set; }

        public int TypeID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string FileUrl { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public int ReferrenceCount { get; set; }
    }
}
