namespace FinalByMyself_0522.Models
{
    public class TicketAttachment
    {
        //五个属性
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string FileUrl { get; set; }

        //建立关系

        //Many(TicketAttachment) To One
        public int TicketId { get; set; }
        public Ticket? ticket { get; set; }
        public string UserId { get; set; }//UserId通常为string
        public AppUser? AppUser { get; set; }
    }
}
