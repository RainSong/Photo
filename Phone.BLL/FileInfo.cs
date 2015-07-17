using Photo.DAL;
using System.Data.Entity;
using System.Linq;

namespace Photo.BLL
{
    public class FileInfo
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

    }
}
