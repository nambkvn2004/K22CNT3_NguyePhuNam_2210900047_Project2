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
    public class NpnCT_HOA_DONController : Controller
    {
        private NpnEntities db = new NpnEntities();

        // GET: NpnCT_HOA_DON
        public ActionResult Index()
        {
            var cT_HOA_DON = db.CT_HOA_DON.Include(c => c.HOA_DON).Include(c => c.SAN_PHAM_CT);
            return View(cT_HOA_DON.ToList());
        }

        // GET: NpnCT_HOA_DON/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HOA_DON cT_HOA_DON = db.CT_HOA_DON.Find(id);
            if (cT_HOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(cT_HOA_DON);
        }

        // GET: NpnCT_HOA_DON/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HOA_DON, "MaHD", "Hoten_nguoinhan");
            ViewBag.MaSPCT = new SelectList(db.SAN_PHAM_CT, "MaSPCT", "MaSPCT");
            return View();
        }

        // POST: NpnCT_HOA_DON/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaSPCT,So_luong_ban,Gia_ban,Tra_lai")] CT_HOA_DON cT_HOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.CT_HOA_DON.Add(cT_HOA_DON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HOA_DON, "MaHD", "Hoten_nguoinhan", cT_HOA_DON.MaHD);
            ViewBag.MaSPCT = new SelectList(db.SAN_PHAM_CT, "MaSPCT", "MaSPCT", cT_HOA_DON.MaSPCT);
            return View(cT_HOA_DON);
        }

        // GET: NpnCT_HOA_DON/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HOA_DON cT_HOA_DON = db.CT_HOA_DON.Find(id);
            if (cT_HOA_DON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HOA_DON, "MaHD", "Hoten_nguoinhan", cT_HOA_DON.MaHD);
            ViewBag.MaSPCT = new SelectList(db.SAN_PHAM_CT, "MaSPCT", "MaSPCT", cT_HOA_DON.MaSPCT);
            return View(cT_HOA_DON);
        }

        // POST: NpnCT_HOA_DON/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaSPCT,So_luong_ban,Gia_ban,Tra_lai")] CT_HOA_DON cT_HOA_DON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_HOA_DON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HOA_DON, "MaHD", "Hoten_nguoinhan", cT_HOA_DON.MaHD);
            ViewBag.MaSPCT = new SelectList(db.SAN_PHAM_CT, "MaSPCT", "MaSPCT", cT_HOA_DON.MaSPCT);
            return View(cT_HOA_DON);
        }

        // GET: NpnCT_HOA_DON/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HOA_DON cT_HOA_DON = db.CT_HOA_DON.Find(id);
            if (cT_HOA_DON == null)
            {
                return HttpNotFound();
            }
            return View(cT_HOA_DON);
        }

        // POST: NpnCT_HOA_DON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_HOA_DON cT_HOA_DON = db.CT_HOA_DON.Find(id);
            db.CT_HOA_DON.Remove(cT_HOA_DON);
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
