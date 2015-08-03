using Photo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.BLL
{
    public class Tag
    {
        public IEnumerable<Model.Tag> GetTags(Func<Model.Tag, bool> fun)
        {
            using (var dbContext = new PhotoContext())
            {
                return dbContext.Tags.Where(fun).OrderByDescending(o => o.citations).ToList();
            }
        }
        /// <summary>
        /// 获取引用大于某个值的Tag
        /// </summary>
        /// <param name="citations"></param>
        /// <returns></returns>
        public IEnumerable<Model.Tag> GetTags(int citations)
        {
            Func<Model.Tag, bool> fun = (tag) =>
            {
                return tag.citations > citations;
            };
            return GetTags(fun);
        }

        public IEnumerable<Model.Tag> GetPageTags(int pageId)
        {
            using (var dbContext = new PhotoContext())
            {
                var result = (from t in dbContext.Tags
                              join pt in dbContext.PageTags on t.id equals pt.tag_id into ptTemp
                              from ptt in ptTemp.DefaultIfEmpty()
                              join p in dbContext.PageTags on ptt.page_id equals p.page_id into pageTemps
                              from pageTemp in pageTemps.DefaultIfEmpty()
                              where pageTemp.page_id == pageId
                              select t).OrderByDescending(o => o.citations).ToList();
                return result;

            }
        }
    }
}
