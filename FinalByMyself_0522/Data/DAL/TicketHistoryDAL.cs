using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.DAL
{
    public class TicketHistoryDAL : IDAL<TicketHistory>
    {
        public ApplicationDbContext Context { get; set; }
        public TicketHistoryDAL(ApplicationDbContext context)
        {
            Context = context;
        }

        //Create
        public void Add(TicketHistory entity)
        {
            Context.TicketHistory.Add(entity);//Q?Context.Add(TicketHistory);
        }

        //Read

        //此方法是后期加上去的，前面IDAL中没有
        public TicketHistory GetById(int id)
        {
            return Context.TicketHistory.First(x => x.Id == id);
        }

        public TicketHistory Get(Func<TicketHistory, bool> firstFuction)
        {
            return Context.TicketHistory.First(firstFuction);
        }

        public ICollection<TicketHistory> GetAll()
        {
            return Context.TicketHistory.ToList();
        }

        public ICollection<TicketHistory> GetList(Func<TicketHistory, bool> whereFuction)
        {
            return Context.TicketHistory.Where(whereFuction).ToList();
        }

        public void Update(TicketHistory entity)
        {
            Context.TicketHistory.Update(entity);
        }

        public void Delete(TicketHistory entity)
        {
            Context.TicketHistory.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
