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
    public class NpnHINH_ANHController : Controller
    {
        private NpnEntities db = new NpnEntities();

        // GET: NpnHINH_ANH
        public ActionResult Index()
        {
            var hINH_ANH = db.HINH_ANH.Include(h => h.SAN_PHAM);
            return View(hINH_ANH.ToList());
        }

        // GET: NpnHINH_ANH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINH_ANH hINH_ANH = db.HINH_ANH.Find(id);
            if (hINH_ANH == null)
            {
                return HttpNotFound();
            }
            return View(hINH_ANH);
        }

        // GET: NpnHINH_ANH/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Ten_sp");
            return View();
        }

        // POST: NpnHINH_ANH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHA,Ten_file_anh,Trang_thai,MaSP")] HINH_ANH hINH_ANH)
        {
            if (ModelState.IsValid)
            {
                db.HINH_ANH.Add(hINH_ANH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Ten_sp", hINH_ANH.MaSP);
            return View(hINH_ANH);
        }

        // GET: NpnHINH_ANH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINH_ANH hINH_ANH = db.HINH_ANH.Find(id);
            if (hINH_ANH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Ten_sp", hINH_ANH.MaSP);
            return View(hINH_ANH);
        }

        // POST: NpnHINH_ANH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHA,Ten_file_anh,Trang_thai,MaSP")] HINH_ANH hINH_ANH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hINH_ANH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "Ten_sp", hINH_ANH.MaSP);
            return View(hINH_ANH);
        }

        // GET: NpnHINH_ANH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HINH_ANH hINH_ANH = db.HINH_ANH.Find(id);
            if (hINH_ANH == null)
            {
                return HttpNotFound();
            }
            return View(hINH_ANH);
        }

        // POST: NpnHINH_ANH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HINH_ANH hINH_ANH = db.HINH_ANH.Find(id);
            db.HINH_ANH.Remove(hINH_ANH);
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
