namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbContextVB : DbContext
    {
        public DbContextVB()
            : base("name=DbContextVB")
        {
        }

        public virtual DbSet<FileDinhKem> FileDinhKems { get; set; }
        public virtual DbSet<LoaiVanBan> LoaiVanBans { get; set; }
        public virtual DbSet<MucDoKhan> MucDoKhans { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<PhongBanKhoa> PhongBanKhoas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<VanBanDen> VanBanDens { get; set; }
        public virtual DbSet<VanBanDi> VanBanDis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileDinhKem>()
                .Property(e => e.IDFileDinhKem)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FileDinhKem>()
                .HasMany(e => e.VanBanDens)
                .WithOptional(e => e.FileDinhKem)
                .WillCascadeOnDelete();

            modelBuilder.Entity<FileDinhKem>()
                .HasMany(e => e.VanBanDis)
                .WithOptional(e => e.FileDinhKem)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiVanBan>()
                .Property(e => e.IDLVB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LoaiVanBan>()
                .HasMany(e => e.VanBanDens)
                .WithOptional(e => e.LoaiVanBan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiVanBan>()
                .HasMany(e => e.VanBanDis)
                .WithOptional(e => e.LoaiVanBan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MucDoKhan>()
                .Property(e => e.IDDoKhan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MucDoKhan>()
                .HasMany(e => e.VanBanDens)
                .WithOptional(e => e.MucDoKhan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MucDoKhan>()
                .HasMany(e => e.VanBanDis)
                .WithOptional(e => e.MucDoKhan)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.IDNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.IDPhongBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.IDPhanQuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.VanBanDens)
                .WithOptional(e => e.NhanVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.VanBanDis)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.IDNhanVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.VanBanDis1)
                .WithOptional(e => e.NhanVien1)
                .HasForeignKey(e => e.IDNguoiGui);

            modelBuilder.Entity<PhanQuyen>()
                .Property(e => e.IDPhanQuyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhanQuyen>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.PhanQuyen)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PhongBanKhoa>()
                .Property(e => e.IDPhongBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhongBanKhoa>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.PhongBanKhoa)
                .WillCascadeOnDelete();

            modelBuilder.Entity<VanBanDen>()
                .Property(e => e.IDVanBanDen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDen>()
                .Property(e => e.IDLVB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDen>()
                .Property(e => e.IDDoKhan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDen>()
                .Property(e => e.IDFileDinhKem)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDen>()
                .Property(e => e.IDNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDi>()
                .Property(e => e.IDVanBanDi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDi>()
                .Property(e => e.IDLVB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDi>()
                .Property(e => e.IDDoKhan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDi>()
                .Property(e => e.IDNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDi>()
                .Property(e => e.IDFileDinhKem)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VanBanDi>()
                .Property(e => e.IDNguoiGui)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
