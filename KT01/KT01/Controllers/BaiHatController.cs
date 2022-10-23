using KT01.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KT01.Controllers
{
    public class BaiHatController : Controller
    {
        BHServices bhs;
        public BaiHatController()
        {
            bhs = new BHServices();
        }
        //
        // GET: /BaiHat/
        public ActionResult Index()
        {
            int count = 0;
            List<Models.BaiHat> tmp = new List<Models.BaiHat>();
            bhs.GetAll().ForEach(x => {
                if (count < 5)
                {
                    tmp.Add(x);
                }
                count++;
            });
            ViewBag.Count = tmp.Count;
            return View(tmp);
        }
        public ActionResult ShowAll()
        {
            var list = bhs.GetAll();
            ViewBag.Count = list.Count;
            return View(list);
        }
        public ActionResult SearchByName(string txt_Search)
        {
            List<Models.BaiHat> list = bhs.GetAll().Where(x => x.Ten.Contains(txt_Search)).ToList();
            ViewBag.Count = list.Count;
            return View("Index", list);
        }
        public ActionResult SortByName()
        {
            List<Models.BaiHat> list = bhs.GetAll().OrderBy(x => x.Ten).ToList();
            ViewBag.Count = list.Count;
            return View("Index", list);
        }
	}
}