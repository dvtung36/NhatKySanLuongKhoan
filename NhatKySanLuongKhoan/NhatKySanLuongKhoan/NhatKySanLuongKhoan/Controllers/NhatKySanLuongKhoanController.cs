using NhatKySanLuongKhoan.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.IO;

namespace NhatKySanLuongKhoan.Controllers
{
    public class NhatKySanLuongKhoanController : Controller
    {
        private Model1 db = new Model1();
        // GET: NhatKySanLuongKhoan
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var model = db.NKSLKs.Where(x => x.MaKhoan != null).ToList();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult Create()
        {

            NKSLK nKSLK = new NKSLK();
            return View(nKSLK);
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
        public ActionResult Create([Bind(Include = "MaKhoan,TenKhoan,Ngaythuchien,Giobatdau,Gioketthuc")] NKSLK nKSLK)
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
        public ActionResult Edit([Bind(Include = "MaKhoan,TenKhoan,Ngaythuchien,Giobatdau,Gioketthuc")] NKSLK nKSLK)
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
        [HttpPost]
        public ActionResult timkiem(string search)
        {
            var model = db.NKSLKs.Where(x => x.TenKhoan.Contains(search)).ToList();
            int pageSize = 6;
            int pageNumber = (1);
            return View("Index", model.ToPagedList(pageNumber, pageSize));

        }
    }
}