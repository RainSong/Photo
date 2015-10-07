using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Photo.Web.Controllers
{
    public class TagController : Controller
    {
        //
        // GET: /Tag/
        [ChildActionOnly]
        public PartialViewResult TagMenu()
        {
            Photo.BLL.Tag bllTag = new Photo.BLL.Tag();
            var tags = bllTag.GetTags(20);
            List<Models.Tag> list = new List<Models.Tag>();
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    list.Add(new Models.Tag
                    {
                        ID = tag.id,
                        Name = tag.tag,
                        Citations = tag.citations
                    });
                }
            }
            return PartialView(list);
        }

        public ViewResult Pages()
        {
            var list = new List<Model.PageInfo>();

            return View(list);
        }

    }
}
