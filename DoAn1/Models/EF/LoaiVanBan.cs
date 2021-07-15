namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiVanBan")]
    public partial class LoaiVanBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiVanBan()
        {
            VanBanDens = new HashSet<VanBanDen>();
            VanBanDis = new HashSet<VanBanDi>();
        }

        [Key]
        [StringLength(10)]
        public string IDLVB { get; set; }

        [StringLength(50)]
        public string TenLVB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VanBanDen> VanBanDens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VanBanDi> VanBanDis { get; set; }
    }
}
