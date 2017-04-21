namespace Qx.Permission.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class menu_extension
    {
        [Key]
        [StringLength(100)]
        public string MenuID { get; set; }

        [StringLength(50)]
        public string Controller { get; set; }

        [StringLength(50)]
        public string Action { get; set; }

        [StringLength(50)]
        public string Area { get; set; }

        [StringLength(50)]
        public string ImageClass { get; set; }

        [StringLength(50)]
        public string ActiveLi { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string ParentId { get; set; }

        [StringLength(50)]
        public string IsParent { get; set; }

        [StringLength(50)]
        public string SubSystem { get; set; }

        public virtual menu menu { get; set; }
    }
}
