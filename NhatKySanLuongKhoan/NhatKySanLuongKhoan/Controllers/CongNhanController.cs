using NhatKySanLuongKhoan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}