using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountingSoftware.Models;

namespace AccountingSoftware.Areas.Administrator.Controllers
{
    public class ThamSoTinhLuongController : Controller
    {
        private AccountingSoftwareDbContext db = new AccountingSoftwareDbContext();

        // GET: Administrator/ThamSoTinhLuong
        public ActionResult Index()
        {
            return View(db.ThamSoTinhLuongs.ToList());
        }

        // GET: Administrator/ThamSoTinhLuong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThamSoTinhLuong thamSoTinhLuong = db.ThamSoTinhLuongs.Find(id);
            if (thamSoTinhLuong == null)
            {
                return HttpNotFound();
            }
            return View(thamSoTinhLuong);
        }

        // GET: Administrator/ThamSoTinhLuong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/ThamSoTinhLuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThamSo,ThangNam,CongLuong,GioCongNgay,HsNgayThuong,HsNgayLe,PcAn,TLBHXH,TLBHYT,TLBHTN,TLKPCD,GiamTruBanThan,GiamTruNPT")] ThamSoTinhLuong thamSoTinhLuong)
        {
            if (ModelState.IsValid)
            {
                db.ThamSoTinhLuongs.Add(thamSoTinhLuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thamSoTinhLuong);
        }

        // GET: Administrator/ThamSoTinhLuong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThamSoTinhLuong thamSoTinhLuong = db.ThamSoTinhLuongs.Find(id);
            if (thamSoTinhLuong == null)
            {
                return HttpNotFound();
            }
            return View(thamSoTinhLuong);
        }

        // POST: Administrator/ThamSoTinhLuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThamSo,ThangNam,CongLuong,GioCongNgay,HsNgayThuong,HsNgayLe,PcAn,TLBHXH,TLBHYT,TLBHTN,TLKPCD,GiamTruBanThan,GiamTruNPT")] ThamSoTinhLuong thamSoTinhLuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thamSoTinhLuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thamSoTinhLuong);
        }

        // GET: Administrator/ThamSoTinhLuong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThamSoTinhLuong thamSoTinhLuong = db.ThamSoTinhLuongs.Find(id);
            if (thamSoTinhLuong == null)
            {
                return HttpNotFound();
            }
            return View(thamSoTinhLuong);
        }

        // POST: Administrator/ThamSoTinhLuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThamSoTinhLuong thamSoTinhLuong = db.ThamSoTinhLuongs.Find(id);
            db.ThamSoTinhLuongs.Remove(thamSoTinhLuong);
            db.SaveChanges();
            return RedirectToAction("Index");
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
