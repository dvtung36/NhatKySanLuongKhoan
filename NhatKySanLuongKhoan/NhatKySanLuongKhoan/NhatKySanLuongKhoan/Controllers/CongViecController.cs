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
    public class CongViecController : Controller
    {
        private Model1 db = new Model1();
        // GET: CongViec
        public ActionResult Index(int? page)
        {

            //var model =  db.CVs.Where(x => x.MaCV != null).ToList();
            //return View(model);
            if (page == null) page = 1;
            var model = db.CVs.Where(x => x.MaCV != null).ToList();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {

         //   ViewBag.id_danh_muc_cong_viec = new SelectList(db.DMCVs, "MaCV","MaCV");
            ViewBag.id_sanpham = new SelectList(db.SANPHAMs, "MaSP", "TenSP");
            return View();
        }
        public ActionResult Edit(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV congViec = db.CVs.Find(id);
            if (congViec == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_sanpham = new SelectList(db.SANPHAMs, "MaSP", "MaSP");
            return View(congViec);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV congViec = db.CVs.Find(id);
            if (congViec == null)
            {
                return HttpNotFound();
            }
            return View(congViec);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCV,TenCV,DinhMucKhoan,DonViKhoan,HeSoKhoan,DinhMucLaoDong,DonGia,MaSP")] CV congViec)
        {
            if (ModelState.IsValid)
            {
                db.CVs.Add(congViec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_sanpham = new SelectList(db.SANPHAMs, "MaSP", "MaSP");
            return View(congViec);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCV,TenCV,DinhMucKhoan,DonViKhoan,HeSoKhoan,DinhMucLaoDong,DonGia,MaSP")] CV congViec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congViec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_sanpham = new SelectList(db.SANPHAMs, "MaSP", "MaSP");
            return View(congViec);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CV congViec = db.CVs.Find(id);
            db.CVs.Remove(congViec);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult timkiem(string search)
        {
            var model = db.CVs.Where(x => x.TenCV.Contains(search)).ToList();
            return View("Index", model);
        }


    }
}