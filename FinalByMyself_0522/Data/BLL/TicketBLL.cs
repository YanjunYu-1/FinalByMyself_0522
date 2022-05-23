using FinalByMyself_0522.Data.DAL;
using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.BLL
{
    public class TicketBLL
    {
        TicketDAL ticketDAL;
        public TicketBLL(TicketDAL td)
        {
            ticketDAL = td;
        }
        public ICollection<Ticket> GetAll()
        {
            return ticketDAL.GetAll();
        }

        public void Update(Ticket ticket)
        {
            ticketDAL.Update(ticket);
        }
        public void Save()
        {
            ticketDAL.Save();
        }
    }
}
