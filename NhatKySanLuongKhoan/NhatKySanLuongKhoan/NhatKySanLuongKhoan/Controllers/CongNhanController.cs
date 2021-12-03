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
    public class CongNhanController : Controller
    {
        private Model1 db = new Model1();

        // GET: CongNhan
        public ActionResult Index()
        {
            var model = db.NHANCONGs.Where(x => x.MaNC != null).ToList();
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
            NHANCONG congNhan = db.NHANCONGs.Find(id);
            if (congNhan == null)
            {
                return HttpNotFound();
            }
            return View(congNhan);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANCONG congNhan = db.NHANCONGs.Find(id);
            if (congNhan == null)
            {
                return HttpNotFound();
            }
            return View(congNhan);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNC,HoTen,NgaySinh,PhongBan,ChucVu,QueQuan,LuongHopDong,LuongBaoHiem,GioiTinh")] NHANCONG congNhan)
        {
            if (ModelState.IsValid)
            {
                db.NHANCONGs.Add(congNhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(congNhan);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNC,HoTen,NgaySinh,PhongBan,ChucVu,QueQuan,LuongHopDong,LuongBaoHiem,GioiTinh")] NHANCONG congNhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congNhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(congNhan);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANCONG congViec = db.NHANCONGs.Find(id);
            db.NHANCONGs.Remove(congViec);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult timkiem(string search)
        {
            var model = db.NHANCONGs.Where(x => x.Hoten.Contains(search)).ToList();
            return View("Index", model);
        }
    }
}