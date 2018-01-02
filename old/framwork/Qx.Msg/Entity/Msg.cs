namespace Qx.Msg.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("msg")]
    public partial class msg
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public msg()
        {
            msg_collection = new HashSet<msg_collection>();
            msg_send_record = new HashSet<msg_send_record>();
            timer_msg = new HashSet<timer_msg>();
        }

        [StringLength(50)]
        public string MsgID { get; set; }

        [StringLength(50)]
        public string MsgTypeID { get; set; }

        [StringLength(50)]
        public string Subjects { get; set; }

        public string Contents { get; set; }

        public DateTime CreationTime { get; set; }

        [StringLength(50)]
        public string SenderID { get; set; }

        public virtual msg_type msg_type { get; set; }

        public virtual msg_user msg_user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<msg_collection> msg_collection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<msg_send_record> msg_send_record { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<timer_msg> timer_msg { get; set; }
    }
}
