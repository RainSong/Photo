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
        public IEnumerable<Model.Tag> GetTags(Func<Model.Tag,bool> fun)
        {
            using (var dbContext = new PhotoContext()) 
            {
                return dbContext.Tags.Where(fun).OrderByDescending(o => o.citations).ToList();
            }
        }

        public IEnumerable<Model.Tag> GetTags(int citations)
        {
            Func<Model.Tag, bool> fun = (tag) => 
            {
                return tag.citations > citations;
            };
            return GetTags(fun);
        }
    }
}
