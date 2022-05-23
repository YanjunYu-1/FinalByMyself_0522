using FinalByMyself_0522.Data.DAL;
using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.BLL
{
    public class TicketAttachmentBLL
    {
        public TicketAttachmentDAL repo;
        public TicketAttachmentBLL(TicketAttachmentDAL repoPb)
        {
            this.repo = repoPb;
        }
        public void Add(TicketAttachment entity)
        {
            repo.Add(entity);
        }
        public TicketAttachment Get(Func<TicketAttachment, bool> firstFuction)
        {
            return repo.Get(firstFuction);
        }
        public ICollection<TicketAttachment> GetAll()
        {
            return repo.GetAll();
        }
        public ICollection<TicketAttachment> GetList(Func<TicketAttachment, bool> whereFuction)
        {
            return repo.GetList(whereFuction);
        }

        public void Update(TicketAttachment entity)
        {
            repo.Update(entity);
        }
        public void Save()
        {
            repo.Save();
        }
    }
}
