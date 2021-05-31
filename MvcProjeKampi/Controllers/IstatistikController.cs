using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
       
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());


        public ActionResult Index()
        {
            List<SelectListItem> totalnumberofcategories = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();



            List<SelectListItem> writerwithlettera = (from x in wm.GetList() where x.WriterName.ToUpper().Contains("A") select  new SelectListItem { Text=x.WriterName,
                                                                                                                                            Value=x.WriterID.ToString()} 
                                                     ).ToList();


            List<SelectListItem> withyazılımtitle = (from x in hm.List() where x.Category.CategoryName.Contains("Yazılım")
                                                        select new SelectListItem
                                                            {
                                                                Value = x.HeadingID.ToString()
                                                            }).ToList();



            // var categorywiththemosttitles = (from x in hm.List() orderby x.CategoryID group x by x.Category.CategoryName into grup select grup.Key).First()


            var categorywiththemosttitles = hm.List().GroupBy(q => q.CategoryID).OrderByDescending(gp => gp.Count()).Take(1).Select(s => s.FirstOrDefault().Category.CategoryName ).First();

            bool Val = true;
            bool invalid = false;



            //True False Farkı

            var c = (from x in cm.GetList() where (x.CategoryStatus == Val) select x.CategoryStatus).Count();

            var b= (from x in cm.GetList() where (x.CategoryStatus == invalid) select x.CategoryStatus).Count();


            ViewBag.a = (c-b);

            ViewBag.vlc = totalnumberofcategories.Count();
            ViewBag.clw = writerwithlettera.Count();
            ViewBag.wly= withyazılımtitle.Count();
            ViewBag.wmt = categorywiththemosttitles;

            return View();
        }
    }
}