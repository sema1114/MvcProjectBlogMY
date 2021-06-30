using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        // GET: Heading
        public ActionResult Index()
        {
            var headingValues = hm.List();
            return View(headingValues);
        }

        public ActionResult HeadingReport()
        {
            var headingValues = hm.List();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> cetegoryValue = (from x in cm.GetList() select new SelectListItem { 
                                                                                                     Text=x.CategoryName,
                                                                                                     Value=x.CategoryID.ToString()
                                                                                                     }).ToList();


            List<SelectListItem> writerValue = (from i in wm.GetList() select new SelectListItem {  
                                                                                             Text= i.WriterName +" "+i.WriterSurname,
                                                                                             Value=i.WriterID.ToString()
                                                                                               }).ToList();


            ViewBag.vlw = writerValue;
            ViewBag.vlc = cetegoryValue;

            return View();
        }

        [HttpPost]

        public ActionResult AddHeading(Heading heading)
        {

            heading.HeadingDate =DateTime.Parse( DateTime.Now.ToShortDateString());

            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> cetegoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = cetegoryValue;
            var valuesEHeading =hm.GetById(id);
            return View(valuesEHeading);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
           var value= hm.GetById(id);
            value.HeadingStatus = false;
            hm.HeadingDelete(value);

            return RedirectToAction("Index");

        }



    }
}