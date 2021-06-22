using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMessageService
    {

        Message GetById(int id);
        List<Message> GetListInbox(string p);
        List<Message> GetListSendBox(string p);
        void MessageAdd(Message message);
        void MessageUpdate(Message message);
        void MessageDelete(Message message);


    }
}
