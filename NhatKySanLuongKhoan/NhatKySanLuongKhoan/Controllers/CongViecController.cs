using NhatKySanLuongKhoan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhatKySanLuongKhoan.Controllers
{
    public class CongViecController : Controller
    {
        private Model1 db = new Model1();
        // GET: CongViec
        public ActionResult Index()
        {
            //var congViec = db.CVs.Include(c => c.).Include(c => c.SanPham);
            //return View(congViec.ToList());

            var model =  db.CVs.Where(x => x.MaCV != null).ToList();
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