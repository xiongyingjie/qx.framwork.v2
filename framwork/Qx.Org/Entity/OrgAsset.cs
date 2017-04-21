using System.ComponentModel.DataAnnotations;

namespace Qx.Org.Entity
{
    public partial class OrgAsset
    {
        [StringLength(50)]
        public string OrgAssetID { get; set; }

        [StringLength(50)]
        public string O_ID { get; set; }

        public double? Price { get; set; }

        public int? Num { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? TypeID { get; set; }

        public virtual OrgAssetType OrgAssetType { get; set; }

        public virtual Orgnization Orgnization { get; set; }
    }
}
