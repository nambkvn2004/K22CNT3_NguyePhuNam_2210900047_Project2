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
    public class NpnHOA_DONController : Controller
    {
        private NpnEntities db = new NpnEntities();

        // GET: NpnHOA_DON
        public ActionResult Index()
        {
            var hOA_DON = db.HOA_DON.Include(h => h.KHACH_HANG).Include(h => h.PT_THANH_TOAN).Include(h => h.PT_VAN_CHUYEN);
            return View(hOA_DON.ToList());
        }

        // GET: NpnHOA_DON/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            if (hOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(hOA_DON);
        }

        // GET: NpnHOA_DON/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten");
            ViewBag.MaPTTT = new SelectList(db.PT_THANH_TOAN, "MaPTTT", "Ten_PTTT");
            ViewBag.MaPTVC = new SelectList(db.PT_VAN_CHUYEN, "MaPTVC", "Ten_PTVC");
            return View();
        }

        // POST: NpnHOA_DON/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,Ngay_HD,Hoten_nguoinhan,Diachi_nguoinhan,Dienthoai_nguoinhan,Diachi_email,Ngay_giao_hang,Trang_thai,MaKH,MaPTVC,MaPTTT")] HOA_DON hOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.HOA_DON.Add(hOA_DON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", hOA_DON.MaKH);
            ViewBag.MaPTTT = new SelectList(db.PT_THANH_TOAN, "MaPTTT", "Ten_PTTT", hOA_DON.MaPTTT);
            ViewBag.MaPTVC = new SelectList(db.PT_VAN_CHUYEN, "MaPTVC", "Ten_PTVC", hOA_DON.MaPTVC);
            return View(hOA_DON);
        }

        // GET: NpnHOA_DON/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            if (hOA_DON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", hOA_DON.MaKH);
            ViewBag.MaPTTT = new SelectList(db.PT_THANH_TOAN, "MaPTTT", "Ten_PTTT", hOA_DON.MaPTTT);
            ViewBag.MaPTVC = new SelectList(db.PT_VAN_CHUYEN, "MaPTVC", "Ten_PTVC", hOA_DON.MaPTVC);
            return View(hOA_DON);
        }

        // POST: NpnHOA_DON/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,Ngay_HD,Hoten_nguoinhan,Diachi_nguoinhan,Dienthoai_nguoinhan,Diachi_email,Ngay_giao_hang,Trang_thai,MaKH,MaPTVC,MaPTTT")] HOA_DON hOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOA_DON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", hOA_DON.MaKH);
            ViewBag.MaPTTT = new SelectList(db.PT_THANH_TOAN, "MaPTTT", "Ten_PTTT", hOA_DON.MaPTTT);
            ViewBag.MaPTVC = new SelectList(db.PT_VAN_CHUYEN, "MaPTVC", "Ten_PTVC", hOA_DON.MaPTVC);
            return View(hOA_DON);
        }

        // GET: NpnHOA_DON/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            if (hOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(hOA_DON);
        }

        // POST: NpnHOA_DON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOA_DON hOA_DON = db.HOA_DON.Find(id);
            db.HOA_DON.Remove(hOA_DON);
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
