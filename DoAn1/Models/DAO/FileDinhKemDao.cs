using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class FileDinhKemDao
    {
        DbContextVB db = null;
        public FileDinhKemDao()
        {
            db = new DbContextVB();
        }

        public string LuuFile(string tenFie)
        {
            var fileMoi = new FileDinhKem();

            fileMoi.IDFileDinhKem = "F0" + (db.FileDinhKems.Count() + 1).ToString();
            fileMoi.TenFile = tenFie;

            db.FileDinhKems.Add(fileMoi);
            db.SaveChanges();
            return fileMoi.IDFileDinhKem;
        }

    }
}
