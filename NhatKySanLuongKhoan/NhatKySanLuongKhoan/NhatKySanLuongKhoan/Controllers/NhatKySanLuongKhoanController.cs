using NhatKySanLuongKhoan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NhatKySanLuongKhoan.Controllers
{
    public class NhatKySanLuongKhoanController : Controller
    {
        private Model1 db = new Model1();
        // GET: NhatKySanLuongKhoan
        public ActionResult Index()
        {
            var model = db.NKSLKs.Where(x => x.MaKhoan != null).ToList();
            return View(model);
        }
        public ActionResult Create()
        {

            return View();
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NKSLK nKSLK = db.NKSLKs.Find(id);
            if (nKSLK == null)
            {
                return HttpNotFound();
            }
            return View(nKSLK);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NKSLK nKSLK = db.NKSLKs.Find(id);
            if (nKSLK == null)
            {
                return HttpNotFound();
            }
            return View(nKSLK);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhoan,TenKhoan,Ngaythuchien,GiobatdaucVu,Gioketthuc")] NKSLK nKSLK)
        {
            if (ModelState.IsValid)
            {
                db.NKSLKs.Add(nKSLK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nKSLK);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhoan,TenKhoan,Ngaythuchien,GiobatdaucVu,Gioketthuc")] NKSLK nKSLK)
        {

            if (ModelState.IsValid)
            {
                db.Entry(nKSLK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nKSLK);


        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NKSLK nKSLK = db.NKSLKs.Find(id);
            db.NKSLKs.Remove(nKSLK);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}