using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;


namespace Models.DAO
{
    public class VanBanDenDao
    {
        DbContextVB db = null;
        public VanBanDenDao()
        {
            db = new DbContextVB();
        }

       //Phân trang
        public IEnumerable<VanBanDen> ListAllPaging(string searchString1, string searchString2, string searchString3, int page, int pageSize, string userID)
        {
            IQueryable<VanBanDen> model = db.VanBanDens;
            if (!string.IsNullOrEmpty(searchString1))
            {
                model = model.Where(x => x.TieuDe.Contains(searchString1));
            } else if (!string.IsNullOrEmpty(searchString2))
            {
                model = model.Where(x => x.KyHieuVanBanDen.Contains(searchString2));
            }
            else if (!string.IsNullOrEmpty(searchString3))
            {
                model = model.Where(x => x.NgayGui.ToString() == searchString3);
            }

            return model.Where(x => x.IDNhanVien == userID).OrderByDescending(x => x.NgayGui).ToPagedList(page, pageSize);
        }

        public VanBanDen GetById(string tieuDe)
        {
            return db.VanBanDens.SingleOrDefault(x => x.TieuDe == tieuDe);
        }

        public VanBanDen ViewDetail(string id)
        {
            return db.VanBanDens.Find(id);
        }

        //Xoá
        public bool Delete(string id)
        {
            try
            {
                var vb = db.VanBanDens.Find(id);
                db.VanBanDens.Remove(vb);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //Chuyen doi
        public VanBanDen ThemVanBanDen(VanBanDi vanBanDi)
        {
            VanBanDen vanBanDen = new VanBanDen();
            vanBanDen.IDVanBanDen = (db.VanBanDens.Count() + 1).ToString();
            vanBanDen.IDLVB = vanBanDi.IDLVB;
            vanBanDen.IDDoKhan = vanBanDi.IDDoKhan;
            vanBanDen.IDFileDinhKem = vanBanDi.IDFileDinhKem;
            vanBanDen.IDNhanVien = vanBanDi.IDNhanVien;
            vanBanDen.KyHieuVanBanDen = vanBanDi.KyHieuVanBanDi;
            vanBanDen.NgayGui = DateTime.Now;
            vanBanDen.NgayBanHanh = vanBanDi.NgayBanHanh;
            vanBanDen.NgayCoHieuLuc = vanBanDi.NgayHieuLuc;
            vanBanDen.NoiNhan = vanBanDi.IDNhanVien;
            vanBanDen.NoiDung = vanBanDi.NoiDung;
            vanBanDen.TieuDe = vanBanDi.TieuDe;
            vanBanDen.NguoiKyTen = vanBanDi.NguoiKyTen;
            vanBanDen.HanXuLy = vanBanDi.HanXuLy;
            vanBanDen.TinhTrang = vanBanDi.TinhTrang;
            db.VanBanDens.Add(vanBanDen);
            db.SaveChanges();
            return vanBanDen;
         
        }
    }
}
