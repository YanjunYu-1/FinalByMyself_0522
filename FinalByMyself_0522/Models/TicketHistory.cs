namespace FinalByMyself_0522.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }
        public string Property { get; set; }//属性
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Changed { get; set; }

        //建立关系
        //Many(TicketHistory) To One
        public string UserId { get; set; }
        public AppUser? User { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
