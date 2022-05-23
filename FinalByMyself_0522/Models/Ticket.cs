namespace FinalByMyself_0522.Models
{
    public class Ticket
    {
        //四个属性
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        //一、建立关系

        //Many(Tickets) To One
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        //One(Tickets) To Many
        public ICollection<TicketAttachment> TicketAttachments { get; set; }
        public ICollection<TicketComment> TicketComments { get; set; }
        public ICollection<TicketHistory> TicketHistories { get; set; }
        public ICollection<TicketNotification> TicketNotigications { get; set; }

        //Many(Tickets) To One 与Users有两个关系，所以加两个"?"
        public string? OwnerUserId { get; set; }
        public AppUser? OwnerUser { get; set; }
        public string? AssignedToUserId { get; set; }
        public AppUser? AssignedToUser { get; set; }

        //二、建立选项
        public TicketTypes TicketType { get; set; }
        public TicketPriorities TicketPriority { get; set; }
        public TicketStatus TicketStatus { get; set; }


        public Ticket()
        {
            TicketAttachments = new HashSet<TicketAttachment>();
            TicketComments = new HashSet<TicketComment>();
            TicketHistories = new HashSet<TicketHistory>();
            TicketNotigications = new HashSet<TicketNotification>();
        }
    }

    //二、建立新Class
    public enum TicketStatus
    {
        Submitted,//提交，
        Assigned,//已分配，
        Progressing,//进行中
        Completed//完成的
    }

    public enum TicketPriorities
    {
        High,//高
        Medium,//中
        Low//低
    }

    public enum TicketTypes
    {
        GeneralQuestion,//一般问题，
        BugReport,//错误报告，
        PaymentIssue,//付款问题，
        TechIssue,//技术问题，
        AccountIssue//帐户问题
    }
}
