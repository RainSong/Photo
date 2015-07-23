using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.BLL
{
    public class Page
    {
        public IEnumerable<Model.PageInfo> GetPages(int startRowIndex, int pageSize)
        {
            using (var dbContext = new DAL.PhotoContext())
            {
                var pages = dbContext.PageInfos
                                     .OrderByDescending(p=>p.add_time)
                                     .Skip(startRowIndex)
                                     .Take(pageSize)
                                     .ToList();
                return pages;
            }
        }
    }
}
