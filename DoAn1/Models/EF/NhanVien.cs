namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            VanBanDens = new HashSet<VanBanDen>();
            VanBanDis = new HashSet<VanBanDi>();
            VanBanDis1 = new HashSet<VanBanDi>();
        }

        [Key]
        [StringLength(10)]
        public string IDNhanVien { get; set; }

        [StringLength(10)]
        public string IDPhongBan { get; set; }

        [StringLength(10)]
        public string IDPhanQuyen { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string ChucVu { get; set; }

        public bool? GioiTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VanBanDen> VanBanDens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VanBanDi> VanBanDis { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }

        public virtual PhongBanKhoa PhongBanKhoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VanBanDi> VanBanDis1 { get; set; }
    }
}
