using FinalByMyself_0522.Data.DAL;
using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.BLL
{
    public class TicketBLL
    {
        public TicketDAL repo;
        public TicketBLL(TicketDAL repoPb)
        {
            this.repo = repoPb;
        }

        public void Add(Ticket entity)
        {
            repo.Add(entity);
        }
        public Ticket Get(Func<Ticket, bool> firstFuction)
        {
            return repo.Get(firstFuction);
        }
        public ICollection<Ticket> GetAll()
        {
            return repo.GetAll();
        }
        public ICollection<Ticket> GetList(Func<Ticket, bool> whereFuction)
        {
            return repo.GetList(whereFuction);
        }

        public void Update(Ticket entity)
        {
            repo.Update(entity);
        }
        public void Save()
        {
            repo.Save();
        }
    }
}
