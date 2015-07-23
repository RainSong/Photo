using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Photo.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var pageBll = new BLL.Page();
            var pages = pageBll.GetPages(0, 10);
            if (pages != null)
            {
                var pageIds = pages.Select(o => o.id).AsEnumerable();
                var fileBll = new BLL.File();
                var files = fileBll.GetFileInfos(pageIds);
                if (files != null)
                {
                    foreach (var page in pages) 
                    {
                        page.fiels = files.Where(o => o.PageId == page.id).AsEnumerable();
                    }
                }
            }
            return View(pages);
        }

    }
}
