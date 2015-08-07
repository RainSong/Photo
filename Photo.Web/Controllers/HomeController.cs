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
            RoteValueHelper rvh = new RoteValueHelper();
            var index = rvh.GetInt("index", 1);

            var pageSize = 10;
            var startIndex = (index - 1) * pageSize;
            var pageBll = new BLL.Page();

            var pages = pageBll.GetPages(startIndex, 10);
            List<Photo.Web.Models.Page> list = null;
            if (pages != null)
            {
                var pageIds = pages.Select(o => o.id).AsEnumerable();
                var fileBll = new BLL.File();
                var files = fileBll.GetFileInfos(pageIds);

                if (files != null)
                {
                    var imgs = (from f in files
                                select new Photo.Web.Models.Img
                                {
                                    Id = f.id,
                                    Url = f.url,
                                    Path = f.path,
                                    PageId = f.PageId,
                                    Width = f.width,
                                    Height = f.height
                                }).ToList();
                    list = (from p in pages
                            select new Photo.Web.Models.Page
                            {
                                Id = p.id,
                                AddTime = p.add_time,
                                Title = p.title,
                                Description = p.description,
                                DefaultImg = imgs.FirstOrDefault(o => o.PageId == p.id)
                            }).ToList();
                }
            }
            return View(list);
        }

    }
}
