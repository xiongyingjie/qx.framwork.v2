using System.ComponentModel.DataAnnotations;

namespace xyj.acs.Entity
{
    public partial class organization_relation
    {
        [Key]
        [StringLength(100)]
        public string organization_relation_id { get; set; }

        [Required]
        [StringLength(50)]
        public string orgnization_id { get; set; }

        [Required]
        [StringLength(50)]
        public string other_orgnization_id { get; set; }

        public virtual orgnization orgnization { get; set; }

    }
}
