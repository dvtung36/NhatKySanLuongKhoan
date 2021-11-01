using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhatKySanLuongKhoan.Models;

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
        public ActionResult Edit()
        {

            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}