namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongBanKhoa")]
    public partial class PhongBanKhoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongBanKhoa()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        [Key]
        [StringLength(10)]
        public string IDPhongBan { get; set; }

        [StringLength(50)]
        public string TenPhongBan { get; set; }

        public int? SoLuongNhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
