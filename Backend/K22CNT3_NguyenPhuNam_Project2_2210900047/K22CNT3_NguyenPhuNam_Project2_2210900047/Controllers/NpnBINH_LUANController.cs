using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT3_NguyenPhuNam_Project2_2210900047.Models;

namespace K22CNT3_NguyenPhuNam_2210900047_Project2.Controllers
{
    public class NpnBINH_LUANController : Controller
    {
        private NpnEntities db = new NpnEntities();

        // GET: NpnBINH_LUAN
        public ActionResult Index()
        {
            var bINH_LUAN = db.BINH_LUAN.Include(b => b.KHACH_HANG).Include(b => b.SAN_PHAM);
            return View(bINH_LUAN.ToList());
        }

        // GET: NpnBINH_LUAN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BINH_LUAN bINH_LUAN = db.BINH_LUAN.Find(id);
            if (bINH_LUAN == null)
            {
                return HttpNotFound();
            }
            return View(bINH_LUAN);
        }

        // GET: NpnBINH_LUAN/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten");
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Ten_sp");
            return View();
        }

        // POST: NpnBINH_LUAN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBL,MaKH,MaSP,Tieu_de,Noi_dung,Ngay_BL,Trang_thai")] BINH_LUAN bINH_LUAN)
        {
            if (ModelState.IsValid)
            {
                db.BINH_LUAN.Add(bINH_LUAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", bINH_LUAN.MaKH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Ten_sp", bINH_LUAN.MaSP);
            return View(bINH_LUAN);
        }

        // GET: NpnBINH_LUAN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BINH_LUAN bINH_LUAN = db.BINH_LUAN.Find(id);
            if (bINH_LUAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", bINH_LUAN.MaKH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Ten_sp", bINH_LUAN.MaSP);
            return View(bINH_LUAN);
        }

        // POST: NpnBINH_LUAN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBL,MaKH,MaSP,Tieu_de,Noi_dung,Ngay_BL,Trang_thai")] BINH_LUAN bINH_LUAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bINH_LUAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", bINH_LUAN.MaKH);
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Ten_sp", bINH_LUAN.MaSP);
            return View(bINH_LUAN);
        }

        // GET: NpnBINH_LUAN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BINH_LUAN bINH_LUAN = db.BINH_LUAN.Find(id);
            if (bINH_LUAN == null)
            {
                return HttpNotFound();
            }
            return View(bINH_LUAN);
        }

        // POST: NpnBINH_LUAN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BINH_LUAN bINH_LUAN = db.BINH_LUAN.Find(id);
            db.BINH_LUAN.Remove(bINH_LUAN);
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
