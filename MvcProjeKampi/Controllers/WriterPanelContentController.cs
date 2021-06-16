﻿using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
   
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            Context c = new Context();
                   
            p = (string)Session["WriterMail"];
            // ViewBag.d = p;
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y=>y.WriterID).FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writeridinfo);
            return View(contentvalues);
        }
    }
}