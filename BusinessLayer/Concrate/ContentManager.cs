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
            throw new NotImplementedException();
        }

        public void CategoryDelete(Content category)
        {
            throw new NotImplementedException();
        }

        public void CategoryUpdate(Content category)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList()
        {

            return _contentDal.List();
        }

        public List<Content> GetListByWriter()
        {
            return _contentDal.List(x=>x.WriterID==4);
        }

        public List<Content> GetLİstByHeadingID(int id)
        {
            return _contentDal.List(x=>x.HeadingID==id);
        }
    }
}
