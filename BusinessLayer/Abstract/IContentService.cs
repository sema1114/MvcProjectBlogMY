using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IContentService
    {

        List<Content> GetList(string p);
        List<Content> GetListByWriter(int id);
        List<Content> GetLİstByHeadingID(int id);
        void CategoryAdd(Content category);
        void CategoryDelete(Content category);
        Content GetByID(int id);
        void CategoryUpdate(Content category);
    }
}
