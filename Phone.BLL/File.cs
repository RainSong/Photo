using Photo.DAL;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Photo.BLL
{
    public class File
    {
        public Model.FileInfo Get(int id)
        {
            using (var dbContext = new DAL.PhotoContext())
            {
                return dbContext.FileInfos.Where(o => o.id == id).FirstOrDefault();
            }
        }
        public int Add(Model.FileInfo fileInfo)
        {
            using (var dbContext = new DAL.PhotoContext())
            {
                dbContext.Entry(fileInfo).State = EntityState.Added;
                return dbContext.SaveChanges();
            }
        }

        public int Update(Model.FileInfo fileInfo)
        {
            using (var dbContext = new DAL.PhotoContext())
            {
                dbContext.Entry(fileInfo).State = EntityState.Added;
                return dbContext.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            using (var dbContext = new DAL.PhotoContext())
            {
                var fileInfo = (from f in dbContext.FileInfos
                                where f.id == id
                                select new Model.FileInfo
                                {
                                    id = f.id
                                }).FirstOrDefault();

                dbContext.Entry(fileInfo).State = EntityState.Deleted;
                return dbContext.SaveChanges();
            }
        }

        public IQueryable<Model.FileInfo> GetFileInfos(int pageId)
        {
            using (var dbContext = new PhotoContext())
            {
                var query = (from p in dbContext.PageInfos
                             join pf in dbContext.PageFiles on p.id equals pf.page_id
                             join f in dbContext.FileInfos on pf.file_id equals f.id
                             where p.id == pageId
                             select f).AsQueryable();

                return query;
            }
        }

        /// <summary>
        /// 根据PageID取第一个图片
        /// </summary>
        /// <param name="pageIds"></param>
        /// <returns></returns>
        public IEnumerable<Model.FileInfo> GetFileInfos(IEnumerable<int> pageIds)
        {
            using (var dbContext = new PhotoContext())
            {
                var files = (from pf in dbContext.PageFiles
                             join f in dbContext.FileInfos on pf.file_id equals f.id into t
                             from tt in t.DefaultIfEmpty()
                             where pageIds.Contains(pf.page_id)
                             orderby tt.add_time
                             group tt by pf.page_id into g
                             select new
                             {
                                 PageId = g.Key,
                                 url = g.FirstOrDefault() == null ? string.Empty : g.FirstOrDefault().url,
                                 path = g.FirstOrDefault() == null ? string.Empty : g.FirstOrDefault().path,
                                 width = g.FirstOrDefault() == null ? 0 : g.FirstOrDefault().width,
                                 height = g.FirstOrDefault() == null ? 0 : g.FirstOrDefault().height

                             }).ToList();
                var list = (from f in files
                            select new Model.FileInfo
                            {
                                PageId = f.PageId,
                                url = f.url,
                                path = f.path,
                                width = f.width,
                                height = f.height
                            }).AsEnumerable();

                return list;
            }
        }
    }
}
