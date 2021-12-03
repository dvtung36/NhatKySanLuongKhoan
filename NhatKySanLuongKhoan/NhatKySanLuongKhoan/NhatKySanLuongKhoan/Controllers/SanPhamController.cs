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
   
    public class SanPhamController : Controller
    {
        private Model1 db = new Model1();
        // GET: SanPham
        public ActionResult Index()
        {
            var model = db.SANPHAMs.Where(x => x.MaSP != null).ToList();
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
            SANPHAM sanPham = db.SANPHAMs.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sanPham = db.SANPHAMs.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,SoDK,HanSD,NgayDangKy,QyCach")] SANPHAM sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,SoDK,HanSD,NgayDangKy,QyCach")] SANPHAM sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SANPHAM sanPham = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}