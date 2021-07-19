using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class NhanVienDao
    {
        DbContextVB db = null;
        public NhanVienDao()
        {
            db = new DbContextVB();
        }

        //Đăng nhập
        public int Login(string userMail, string passWord)
        {
            var result = db.NhanViens.SingleOrDefault(x => x.Email == userMail);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.MatKhau == passWord)
                {

                    return 1;

                }
                else
                    return 0;
            }

        }

        public NhanVien GetById(string userMail)
        {
            return db.NhanViens.SingleOrDefault(x => x.Email == userMail);
        }

        //Phân trang
        public IEnumerable<NhanVien> ListAllPaging(string searchString1, string searchString2, int page, int pageSize)
        {
            IQueryable<NhanVien> model = db.NhanViens;
            if (!string.IsNullOrEmpty(searchString1))
            {
                model = model.Where(x => x.HoTen.Contains(searchString1));
            }
            else if (!string.IsNullOrEmpty(searchString2))
            {
                model = model.Where(x => x.PhongBanKhoa.TenPhongBan.Contains(searchString2));
            }

            return model.OrderByDescending(x => x.HoTen).ToPagedList(page, pageSize);
        }

        //Xoá
        public bool Delete(string id)
        {
            try
            {
                var nv = db.NhanViens.Find(id);
                db.NhanViens.Remove(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }

}
