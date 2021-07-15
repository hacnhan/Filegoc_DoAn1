using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyVanBan.Common
{
    [Serializable]
    public class UserLogin
    {
        public string UserID { set; get; }
        public string UserName { set; get; }
        public string UserMail { set; get; }
        public string UserPassword { set; get; }
        public string AuthorID { set; get; }
    }
}