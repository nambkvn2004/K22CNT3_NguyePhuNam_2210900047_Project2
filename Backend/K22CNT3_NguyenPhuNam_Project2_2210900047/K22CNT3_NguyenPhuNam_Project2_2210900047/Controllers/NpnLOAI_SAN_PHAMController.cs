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
    public class NpnLOAI_SAN_PHAMController : Controller
    {
        private NpnEntities db = new NpnEntities();

        // GET: NpnLOAI_SAN_PHAM
        public ActionResult Index()
        {
            return View(db.LOAI_SAN_PHAM.ToList());
        }

        // GET: NpnLOAI_SAN_PHAM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            if (lOAI_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SAN_PHAM);
        }

        // GET: NpnLOAI_SAN_PHAM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NpnLOAI_SAN_PHAM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLSP,Ten_loai,Trang_thai")] LOAI_SAN_PHAM lOAI_SAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.LOAI_SAN_PHAM.Add(lOAI_SAN_PHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAI_SAN_PHAM);
        }

        // GET: NpnLOAI_SAN_PHAM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            if (lOAI_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SAN_PHAM);
        }

        // POST: NpnLOAI_SAN_PHAM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLSP,Ten_loai,Trang_thai")] LOAI_SAN_PHAM lOAI_SAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAI_SAN_PHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAI_SAN_PHAM);
        }

        // GET: NpnLOAI_SAN_PHAM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            if (lOAI_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SAN_PHAM);
        }

        // POST: NpnLOAI_SAN_PHAM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAI_SAN_PHAM lOAI_SAN_PHAM = db.LOAI_SAN_PHAM.Find(id);
            db.LOAI_SAN_PHAM.Remove(lOAI_SAN_PHAM);
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
