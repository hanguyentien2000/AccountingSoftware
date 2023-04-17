using AccountingSoftware.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AccountingSoftware.Areas.Administrator.Controllers
{
    public class BaseController : Controller
    {
        // GET: Administrator/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = Session[ConstaintUser.ADMIN_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Controller = "Account",
                    Action = "Login",
                    Area = "Administrator"
                }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}