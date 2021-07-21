using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class VanBanDiDao
    {
        DbContextVB db = null;
        public VanBanDiDao()
        {
            db = new DbContextVB();
        }

        //Phân trang
        public IEnumerable<VanBanDi> ListAllPaging(string searchString1, string searchString2, string searchString3, int page, int pageSize, string userID)
        {
            IQueryable<VanBanDi> model = db.VanBanDis;
            if (!string.IsNullOrEmpty(searchString1))
            {
                model = model.Where(x => x.TieuDe.Contains(searchString1));
            }
            else if (!string.IsNullOrEmpty(searchString2))
            {
                model = model.Where(x => x.KyHieuVanBanDi.Contains(searchString2));
            }
            else if (!string.IsNullOrEmpty(searchString3))
            {
                model = model.Where(x => x.NgayGui.ToString() == searchString3);
            }

            return model.Where(x => x.IDNguoiGui == userID).OrderByDescending(x => x.NgayGui).ToPagedList(page, pageSize);
        }

        public VanBanDi GetById(string tieuDe)
        {
            return db.VanBanDis.SingleOrDefault(x => x.TieuDe == tieuDe);
        }

        public VanBanDi ViewDetail(string id)
        {
            return db.VanBanDis.Find(id);
        }

        //Xoá
        public bool Delete(string id)
        {
            try
            {
                var vb = db.VanBanDis.Find(id);
                db.VanBanDis.Remove(vb);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //Chuyen doi
        public VanBanDen ChuyenTiepVanBanDen(VanBanDen vanBanChuyenTiep, string idNguoiNhan)
        {
            VanBanDen vanBanDen = new VanBanDen();
            vanBanDen.IDVanBanDen = (db.VanBanDens.Count() + 1).ToString();
            vanBanDen.IDLVB = vanBanChuyenTiep.IDLVB;
            vanBanDen.IDDoKhan = vanBanChuyenTiep.IDDoKhan;
            vanBanDen.IDFileDinhKem = vanBanChuyenTiep.IDFileDinhKem;
            vanBanDen.IDNhanVien = idNguoiNhan;
            vanBanDen.KyHieuVanBanDen = vanBanChuyenTiep.KyHieuVanBanDen;
            vanBanDen.NgayGui = DateTime.Now;
            vanBanDen.NgayBanHanh = vanBanChuyenTiep.NgayBanHanh;
            vanBanDen.NgayCoHieuLuc = vanBanChuyenTiep.NgayCoHieuLuc;
            vanBanDen.NoiNhan = vanBanChuyenTiep.IDNhanVien;
            vanBanDen.NoiDung = vanBanChuyenTiep.NoiDung;
            vanBanDen.TieuDe = vanBanChuyenTiep.TieuDe;
            vanBanDen.NguoiKyTen = vanBanChuyenTiep.NguoiKyTen;
            vanBanDen.HanXuLy = vanBanChuyenTiep.HanXuLy;
            vanBanDen.TinhTrang = vanBanChuyenTiep.TinhTrang;
            db.VanBanDens.Add(vanBanDen);
            db.SaveChanges();
            return vanBanDen;
        }
    }
}
