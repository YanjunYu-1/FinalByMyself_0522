using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.DAL
{
    public class TicketNotificationDAL : IDAL<TicketNotification>
    {
        public ApplicationDbContext Context { get; set; }
        public TicketNotificationDAL(ApplicationDbContext context)
        {
            Context = context;
        }

        //Create
        public void Add(TicketNotification entity)
        {
            Context.TicketNotification.Add(entity);//Q?Context.Add(TicketNotification);
        }

        //Read

        //此方法是后期加上去的，前面IDAL中没有
        public TicketNotification GetById(int id)
        {
            return Context.TicketNotification.First(x => x.Id == id);
        }

        public TicketNotification Get(Func<TicketNotification, bool> firstFuction)
        {
            return Context.TicketNotification.First(firstFuction);
        }

        public ICollection<TicketNotification> GetAll()
        {
            return Context.TicketNotification.ToList();
        }

        public ICollection<TicketNotification> GetList(Func<TicketNotification, bool> whereFuction)
        {
            return Context.TicketNotification.Where(whereFuction).ToList();
        }

        public void Update(TicketNotification entity)
        {
            Context.TicketNotification.Update(entity);
        }

        public void Delete(TicketNotification entity)
        {
            Context.TicketNotification.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
