using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qx.Account.Entity
{
    [Table("account")]
    public partial class account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account()
        {
            account_record = new HashSet<account_record>();
            pay_order = new HashSet<pay_order>();
        }

        [StringLength(100)]
        public string AccountID { get; set; }

        public int Balance { get; set; }

        public DateTime LastUpdateTime { get; set; }

        [StringLength(20)]
        public string AccType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<account_record> account_record { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pay_order> pay_order { get; set; }

        public virtual account_type account_type { get; set; }
    }
}
