using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT3_NguyenPhuNam_Project2_2210900047.Models;

namespace K22CNT3_NguyenPhuNam_Project2_2210900047.Controllers
{
    public class NpnSAN_PHAMController : Controller
    {
        private NpnEntities db = new NpnEntities();

        // GET: NpnSAN_PHAM
        public ActionResult Index()
        {
            var sAN_PHAM = db.SAN_PHAM.Include(s => s.LOAI_SAN_PHAM);
            return View(sAN_PHAM.ToList());
        }

        // GET: NpnSAN_PHAM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // GET: NpnSAN_PHAM/Create
        public ActionResult Create()
        {
            ViewBag.MaLSP = new SelectList(db.LOAI_SAN_PHAM, "MaLSP", "Ten_loai");
            return View();
        }

        // POST: NpnSAN_PHAM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,Ten_sp,Mo_ta,Thong_tin,Gia_goc,Gia_giam_gia,Luot_xem,Ngay_cap_nhat,Trang_thai,MaLSP")] SAN_PHAM sAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.SAN_PHAM.Add(sAN_PHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLSP = new SelectList(db.LOAI_SAN_PHAM, "MaLSP", "Ten_loai", sAN_PHAM.MaLSP);
            return View(sAN_PHAM);
        }

        // GET: NpnSAN_PHAM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLSP = new SelectList(db.LOAI_SAN_PHAM, "MaLSP", "Ten_loai", sAN_PHAM.MaLSP);
            return View(sAN_PHAM);
        }

        // POST: NpnSAN_PHAM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,Ten_sp,Mo_ta,Thong_tin,Gia_goc,Gia_giam_gia,Luot_xem,Ngay_cap_nhat,Trang_thai,MaLSP")] SAN_PHAM sAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAN_PHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLSP = new SelectList(db.LOAI_SAN_PHAM, "MaLSP", "Ten_loai", sAN_PHAM.MaLSP);
            return View(sAN_PHAM);
        }

        // GET: NpnSAN_PHAM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // POST: NpnSAN_PHAM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            db.SAN_PHAM.Remove(sAN_PHAM);
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
