using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.DAL
{
    public class TicketCommentDAL : IDAL<TicketComment>
    {
        public ApplicationDbContext Context { get; set; }
        public TicketCommentDAL(ApplicationDbContext context)
        {
            Context = context;
        }

        //Create
        public void Add(TicketComment entity)
        {
            Context.TicketComment.Add(entity);//Q?Context.Add(TicketComment);
        }

        //Read

        //此方法是后期加上去的，前面IDAL中没有
        public TicketComment GetById(int id)
        {
            return Context.TicketComment.First(x => x.Id == id);
        }

        public TicketComment Get(Func<TicketComment, bool> firstFuction)
        {
            return Context.TicketComment.First(firstFuction);
        }

        public ICollection<TicketComment> GetAll()
        {
            return Context.TicketComment.ToList();
        }

        public ICollection<TicketComment> GetList(Func<TicketComment, bool> whereFuction)
        {
            return Context.TicketComment.Where(whereFuction).ToList();
        }

        public void Update(TicketComment entity)
        {
            Context.TicketComment.Update(entity);
        }

        public void Delete(TicketComment entity)
        {
            Context.TicketComment.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
