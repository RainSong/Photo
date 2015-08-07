using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Photo.Web.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Page/

        public ActionResult Index()
        {
            RoteValueHelper rvh = new RoteValueHelper();
            var pageId = rvh.GetInt("pageId", 1);

            var pageBll = new BLL.Page();
            var tagBll = new BLL.Tag();
            var fileBll = new BLL.File();
            Models.Page page = null;
            try
            {
                var pageInfo = pageBll.GetPage(pageId);
                var tagInfos = tagBll.GetPageTags(pageId);
                var imgs = fileBll.GetFileInfos(pageId);

                page = new Models.Page
                {
                    Title = pageInfo.title,
                    AddTime = pageInfo.add_time
                };
                page.Tags = (from t in tagInfos
                             select new Models.Tag
                             {
                                 ID = t.id,
                                 Name = t.tag
                             }).ToList();
                page.Imgs = (from i in imgs
                             select new Models.Img
                             {
                                 Id = i.id,
                                 Path = i.path
                             }).ToList();
            }
            catch (Exception ex) { }
            return View(page);
        }

    }
}
