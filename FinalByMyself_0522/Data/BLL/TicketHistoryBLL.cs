using FinalByMyself_0522.Data.DAL;
using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.BLL
{
    public class TicketHistoryBLL
    {
        public TicketHistoryDAL repo;
        public TicketHistoryBLL(TicketHistoryDAL repoPb)
        {
            this.repo = repoPb;
        }
        public void Add(TicketHistory entity)
        {
            repo.Add(entity);
        }
        public TicketHistory Get(Func<TicketHistory, bool> firstFuction)
        {
            return repo.Get(firstFuction);
        }
        public ICollection<TicketHistory> GetAll()
        {
            return repo.GetAll();
        }
        public ICollection<TicketHistory> GetList(Func<TicketHistory, bool> whereFuction)
        {
            return repo.GetList(whereFuction);
        }

        public void Update(TicketHistory entity)
        {
            repo.Update(entity);
        }
        public void Save()
        {
            repo.Save();
        }
    }
}
