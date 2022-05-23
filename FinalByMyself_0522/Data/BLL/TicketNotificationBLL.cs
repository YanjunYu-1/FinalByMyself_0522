using FinalByMyself_0522.Data.DAL;
using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.BLL
{
    public class TicketNotificationBLL
    {
        public TicketNotificationDAL repo;
        public TicketNotificationBLL(TicketNotificationDAL repoPb)
        {
            this.repo = repoPb;
        }
        public void Add(TicketNotification entity)
        {
            repo.Add(entity);
        }
        public TicketNotification Get(Func<TicketNotification, bool> firstFuction)
        {
            return repo.Get(firstFuction);
        }
        public ICollection<TicketNotification> GetAll()
        {
            return repo.GetAll();
        }
        public ICollection<TicketNotification> GetList(Func<TicketNotification, bool> whereFuction)
        {
            return repo.GetList(whereFuction);
        }

        public void Update(TicketNotification entity)
        {
            repo.Update(entity);
        }
        public void Save()
        {
            repo.Save();
        }
    }
}
