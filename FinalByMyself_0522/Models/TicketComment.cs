namespace FinalByMyself_0522.Models
{
    public class TicketComment
    {
        //三个属性
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }

        //建立关系
        //Many(Tickets) To One
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public string UserId { get; set; }
        public AppUser? User { get; set; }
    }
}
