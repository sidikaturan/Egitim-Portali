using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
  public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Find(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail ==mail); 
        }
        public List<Message> GetListAll(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail == mail || x.SenderMail == mail);
        }
        public List<Message> GetSendInbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> MessageNoRead(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p).Where(x=> x.MessageRead == true).ToList();
        }
        public List<Message> MessageRead(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p).Where(x => x.MessageRead == false).ToList();
        }
        public void MessageOkundu(Message message)
        {
            if(message.MessageRead == true)
            {
                message.MessageRead = false;
            }
            _messageDal.Update(message);

        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
        public void MessageSilindi(Message message)
        {
            if (message.MessageStatus == true)
            {
                message.MessageStatus = false;
            }
            else
            {
                message.MessageStatus = true;
            }
            _messageDal.Update(message);

        }

    }
}
