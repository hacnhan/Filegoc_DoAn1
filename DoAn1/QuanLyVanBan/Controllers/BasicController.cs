using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using QuanLyVanBan.Common;

namespace QuanLyVanBan.Controllers
{
    public class BasicController : Controller
    {
        // GET: Basic
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}