namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("template")]
    public partial class template
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public template()
        {
            templatedata = new HashSet<templatedata>();
        }

        [StringLength(50)]
        public string TemplateID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string TemplateTypeID { get; set; }

        [StringLength(500)]
        public string Contents { get; set; }

        [StringLength(500)]
        public string Example { get; set; }

        public virtual template_type template_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<templatedata> templatedata { get; set; }
    }
}
