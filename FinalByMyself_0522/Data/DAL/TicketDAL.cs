using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.DAL
{
    public class TicketDAL : IDAL<Ticket>
    {
        public ApplicationDbContext Context { get; set; }
        public TicketDAL(ApplicationDbContext context)
        {
            Context = context;
        }

        //Create
        public void Add(Ticket entity)
        {
            Context.Ticket.Add(entity);//Q?Context.Add(Ticket);
        }

        //Read

        //此方法是后期加上去的，前面IDAL中没有
        public Ticket GetById(int id)
        {
            return Context.Ticket.First(x => x.Id == id);
        }

        public Ticket Get(Func<Ticket, bool> firstFuction)
        {
            return Context.Ticket.First(firstFuction);
        }

        public ICollection<Ticket> GetAll()
        {
            return Context.Ticket.ToList();
        }

        public ICollection<Ticket> GetList(Func<Ticket, bool> whereFuction)
        {
            return Context.Ticket.Where(whereFuction).ToList();
        }

        public void Update(Ticket entity)
        {
            Context.Ticket.Update(entity);
        }

        public void Delete(Ticket entity)
        {
            Context.Ticket.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
