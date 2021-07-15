namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VanBanDen")]
    public partial class VanBanDen
    {
        [Key]
        [StringLength(10)]
        public string IDVanBanDen { get; set; }

        [StringLength(10)]
        public string IDLVB { get; set; }

        [StringLength(10)]
        public string IDDoKhan { get; set; }

        [StringLength(10)]
        public string IDFileDinhKem { get; set; }

        [StringLength(10)]
        public string IDNhanVien { get; set; }

        [StringLength(20)]
        public string KyHieuVanBanDen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGui { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBanHanh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCoHieuLuc { get; set; }

        [StringLength(50)]
        public string NoiNhan { get; set; }

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
    }
}
