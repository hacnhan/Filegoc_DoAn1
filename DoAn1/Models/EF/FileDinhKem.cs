namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FileDinhKem")]
    public partial class FileDinhKem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FileDinhKem()
        {
            VanBanDens = new HashSet<VanBanDen>();
            VanBanDis = new HashSet<VanBanDi>();
        }

        [Key]
        [StringLength(10)]
        public string IDFileDinhKem { get; set; }

        [StringLength(50)]
        public string TenFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VanBanDen> VanBanDens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VanBanDi> VanBanDis { get; set; }
    }
}
