using KT01.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KT01.Controllers
{
    public class AlbumController : Controller
    {
        AlbumServices abs;
        public AlbumController()
        {
            abs = new AlbumServices();
        }
        // GET: /Album/
        public ActionResult Index()
        {
            return View(abs.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string Ten, HttpPostedFileBase uploadFile)
        {
            if (abs.Create(Ten, uploadFile.FileName) == 0)
            {
                ViewBag.Err = "Tên Album đã bị trùng, vui lòng thử lại!";
                return View();
            }
            if (uploadFile != null && uploadFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(uploadFile.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/AnhTest"), fileName);
                uploadFile.SaveAs(path);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(string Ma)
        {
            if (Ma == null)
            {
                return RedirectToAction("Index");    
            }
            var currentAb = abs.GetAll().Where(x => x.Ma == int.Parse(Ma)).FirstOrDefault();
            ViewBag.Name = currentAb.Ten;
            ViewBag.AnhBia = currentAb.AnhBia;
            ViewBag.MaAB = currentAb.Ma;
            return View(abs.GetBaiHatsInAlbum(Ma));
        }
        public ActionResult Delete(string Ma, string MaAB)
        {          
            abs.DeleteBaiHat(Ma, MaAB);
            return RedirectToAction("Details", new { Ma = MaAB});
        }
	}
}