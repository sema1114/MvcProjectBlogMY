using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void CategoryAdd(Content category)
        {
            _contentDal.Insert(category);
        }

        public void CategoryDelete(Content category)
        {
            _contentDal.Delete(category);
        }

        public void CategoryUpdate(Content category)
        {
            _contentDal.Update(category);
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                return _contentDal.List();
            }
            else {
                return _contentDal.List(x => x.ContentValue.Contains(p));
            }
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x=>x.WriterID==id);
        }

        public List<Content> GetLİstByHeadingID(int id)
        {
            return _contentDal.List(x=>x.HeadingID==id);
        }
    }
}
