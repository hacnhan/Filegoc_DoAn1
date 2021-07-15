using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

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

    }

}
