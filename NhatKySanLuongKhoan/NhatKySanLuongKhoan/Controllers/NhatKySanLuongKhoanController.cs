using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NhatKySanLuongKhoan.Models;
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