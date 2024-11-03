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
    public class NpnPHAN_HOIController : Controller
    {
        private NpnEntities db = new NpnEntities();

        // GET: NpnPHAN_HOI
        public ActionResult Index()
        {
            return View(db.PHAN_HOI.ToList());
        }

        // GET: NpnPHAN_HOI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHAN_HOI pHAN_HOI = db.PHAN_HOI.Find(id);
            if (pHAN_HOI == null)
            {
                return HttpNotFound();
            }
            return View(pHAN_HOI);
        }

        // GET: NpnPHAN_HOI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NpnPHAN_HOI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPH,Tieu_de,Noi_dung,Ngay_gui,Email,Facebook,Tra_loi,Trang_thai,Da_xem")] PHAN_HOI pHAN_HOI)
        {
            if (ModelState.IsValid)
            {
                db.PHAN_HOI.Add(pHAN_HOI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHAN_HOI);
        }

        // GET: NpnPHAN_HOI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHAN_HOI pHAN_HOI = db.PHAN_HOI.Find(id);
            if (pHAN_HOI == null)
            {
                return HttpNotFound();
            }
            return View(pHAN_HOI);
        }

        // POST: NpnPHAN_HOI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPH,Tieu_de,Noi_dung,Ngay_gui,Email,Facebook,Tra_loi,Trang_thai,Da_xem")] PHAN_HOI pHAN_HOI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHAN_HOI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHAN_HOI);
        }

        // GET: NpnPHAN_HOI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHAN_HOI pHAN_HOI = db.PHAN_HOI.Find(id);
            if (pHAN_HOI == null)
            {
                return HttpNotFound();
            }
            return View(pHAN_HOI);
        }

        // POST: NpnPHAN_HOI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHAN_HOI pHAN_HOI = db.PHAN_HOI.Find(id);
            db.PHAN_HOI.Remove(pHAN_HOI);
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
