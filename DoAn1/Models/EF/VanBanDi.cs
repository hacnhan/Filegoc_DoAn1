namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VanBanDi")]
    public partial class VanBanDi
    {
        [Key]
        [StringLength(10)]
        public string IDVanBanDi { get; set; }

        [StringLength(10)]
        public string IDLVB { get; set; }

        [StringLength(10)]
        public string IDDoKhan { get; set; }

        [StringLength(10)]
        public string IDNhanVien { get; set; }

        [StringLength(10)]
        public string IDFileDinhKem { get; set; }

        [StringLength(20)]
        public string KyHieuVanBanDi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBanHanh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGui { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHieuLuc { get; set; }

        [StringLength(10)]
        public string IDNguoiGui { get; set; }

        public string NoiDung { get; set; }

        [StringLength(50)]
        public string TieuDe { get; set; }

        [StringLength(50)]
        public string NguoiKyTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanXuLy { get; set; }

        public bool? TinhTrang { get; set; }

        public virtual FileDinhKem FileDinhKem { get; set; }

        public virtual LoaiVanBan LoaiVanBan { get; set; }

        public virtual MucDoKhan MucDoKhan { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual NhanVien NhanVien1 { get; set; }
    }
}
