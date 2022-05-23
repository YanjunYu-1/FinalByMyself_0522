using FinalByMyself_0522.Data.DAL;
using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.BLL
{
    public class TicketCommentBLL
    {
        public TicketCommentDAL repo;
        public TicketCommentBLL(TicketCommentDAL repoPb)
        {
            this.repo = repoPb;
        }
        public void Add(TicketComment entity)
        {
            repo.Add(entity);
        }
        public TicketComment Get(Func<TicketComment, bool> firstFuction)
        {
            return repo.Get(firstFuction);
        }
        public ICollection<TicketComment> GetAll()
        {
            return repo.GetAll();
        }
        public ICollection<TicketComment> GetList(Func<TicketComment, bool> whereFuction)
        {
            return repo.GetList(whereFuction);
        }

        public void Update(TicketComment entity)
        {
            repo.Update(entity);
        }
        public void Save()
        {
            repo.Save();
        }
    }
}
