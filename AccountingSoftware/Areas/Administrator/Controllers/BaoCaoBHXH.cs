using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountingSoftware.Models;
using PagedList;

namespace AccountingSoftware.Areas.Administrator.Controllers
{
    public class BaoCaoBHXHController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/BaoCaoBHXH
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var BaoCaoBHXHs = db.NhanViens.Select(kh => kh);
            if (!String.IsNullOrEmpty(searchString))
            {
                BaoCaoBHXHs = BaoCaoBHXHs.Where(dm => dm.HoTen.Contains(searchString));
            }
            return View(BaoCaoBHXHs.OrderBy(dm => dm.MaNV).ToPagedList(page, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
