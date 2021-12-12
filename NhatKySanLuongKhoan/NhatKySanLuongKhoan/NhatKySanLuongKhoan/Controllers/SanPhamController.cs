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

    public class SanPhamController : Controller
    {
        private Model1 db = new Model1();
        // GET: SanPham
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var model = db.SANPHAMs.Where(x => x.MaSP != null).ToList();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult Create()
        {
            SANPHAM sanPham = new SANPHAM();
            return View(sanPham);
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
        public ActionResult Create(SANPHAM sanPham, HttpPostedFileBase uploadhinh)
        {

            if (ModelState.IsValid)
            {
                if (sanPham.uploadhinh != null && sanPham.uploadhinh.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(sanPham.uploadhinh.FileName);
                    string extension = Path.GetExtension(sanPham.uploadhinh.FileName);
                    filename = filename + extension;
                    sanPham.Hinh = filename;
                    sanPham.uploadhinh.SaveAs(Path.Combine(Server.MapPath("~/Upload/SanPham/"), filename));
                }

                //if (uploadhinh != null)
                //{
                //    string path = Path.Combine(Server.MapPath("~/Upload/SanPham/"), Path.GetFileName(uploadhinh.FileName));
                //    uploadhinh.SaveAs(path);

                //}
                db.SANPHAMs.Add(sanPham);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

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

        [HttpPost]
        public ActionResult timkiem(string search)
        {
            var model = db.SANPHAMs.Where(x => x.TenSP.Contains(search)).ToList();
            int pageSize = 6;
            int pageNumber = (1);
            return View("Index", model.ToPagedList(pageNumber, pageSize));

        }
    }
}