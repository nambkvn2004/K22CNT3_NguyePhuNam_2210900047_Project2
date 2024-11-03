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
    public class NpnLIEN_HEController : Controller
    {
        private NpnEntities db = new NpnEntities();

        // GET: NpnLIEN_HE
        public ActionResult Index()
        {
            return View(db.LIEN_HE.ToList());
        }

        // GET: NpnLIEN_HE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIEN_HE lIEN_HE = db.LIEN_HE.Find(id);
            if (lIEN_HE == null)
            {
                return HttpNotFound();
            }
            return View(lIEN_HE);
        }

        // GET: NpnLIEN_HE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NpnLIEN_HE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLH,Tieu_de,Dia_chi,Dien_thoai,Email,Facebook,Logo,Trang_thai")] LIEN_HE lIEN_HE)
        {
            if (ModelState.IsValid)
            {
                db.LIEN_HE.Add(lIEN_HE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lIEN_HE);
        }

        // GET: NpnLIEN_HE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIEN_HE lIEN_HE = db.LIEN_HE.Find(id);
            if (lIEN_HE == null)
            {
                return HttpNotFound();
            }
            return View(lIEN_HE);
        }

        // POST: NpnLIEN_HE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLH,Tieu_de,Dia_chi,Dien_thoai,Email,Facebook,Logo,Trang_thai")] LIEN_HE lIEN_HE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIEN_HE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lIEN_HE);
        }

        // GET: NpnLIEN_HE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIEN_HE lIEN_HE = db.LIEN_HE.Find(id);
            if (lIEN_HE == null)
            {
                return HttpNotFound();
            }
            return View(lIEN_HE);
        }

        // POST: NpnLIEN_HE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIEN_HE lIEN_HE = db.LIEN_HE.Find(id);
            db.LIEN_HE.Remove(lIEN_HE);
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
