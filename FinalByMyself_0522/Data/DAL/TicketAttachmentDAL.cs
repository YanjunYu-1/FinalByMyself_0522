using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.DAL
{
    public class TicketAttachmentDAL : IDAL<TicketAttachment>
    {
        public ApplicationDbContext Context { get; set; }
        public TicketAttachmentDAL(ApplicationDbContext context)
        {
            Context = context;
        }

        //Create
        public void Add(TicketAttachment entity)
        {
            Context.TicketAttachment.Add(entity);//Q?Context.Add(TicketAttachment);
        }

        //Read

        //此方法是后期加上去的，前面IDAL中没有
        public TicketAttachment GetById(int id)
        {
            return Context.TicketAttachment.First(x => x.Id == id);
        }

        public TicketAttachment Get(Func<TicketAttachment, bool> firstFuction)
        {
            return Context.TicketAttachment.First(firstFuction);
        }

        public ICollection<TicketAttachment> GetAll()
        {
            return Context.TicketAttachment.ToList();
        }

        public ICollection<TicketAttachment> GetList(Func<TicketAttachment, bool> whereFuction)
        {
            return Context.TicketAttachment.Where(whereFuction).ToList();
        }


        //Update
        public void Update(TicketAttachment entity)
        {
            Context.TicketAttachment.Update(entity);
        }

        //Delete
        public void Delete(TicketAttachment entity)
        {
            Context.TicketAttachment.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
