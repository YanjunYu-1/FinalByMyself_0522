namespace FinalByMyself_0522.Models
{
    public class TicketNotification
    {
        public int Id { get; set; }

        //建立关系
        //Many(TicketNotification) To One
        public string UserId { get; set; }
        public AppUser? User { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
