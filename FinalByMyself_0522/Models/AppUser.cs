using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalByMyself_0522.Models
{
    public class AppUser
    {
        //public string Id { get; set; }不需要此行，因为在IdentityUser中有Id

        //One(AppUser) To Many

        [InverseProperty("AssignedToUser")]//逆属性
        public ICollection<Ticket> AssignedTicket { get; set; }

        [InverseProperty("OwnerUser")]//逆属性
        public ICollection<Ticket> OwnerTicket { get; set; }

        public ICollection<TicketAttachment> TicketAttachments { get; set; }
        public ICollection<TicketComment> TicketComments { get; set; }
        public ICollection<TicketHistory> TicketHistories { get; set; }
        public ICollection<TicketNotification> TicketNotifications { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }
        public AppUser()
        {
            AssignedTicket = new HashSet<Ticket>();
            OwnerTicket = new HashSet<Ticket>();
            TicketAttachments = new HashSet<TicketAttachment>();
            TicketComments = new HashSet<TicketComment>();
            TicketHistories = new HashSet<TicketHistory>();
            TicketNotifications = new HashSet<TicketNotification>();
            ProjectUsers = new HashSet<ProjectUser>();
        }
    }
}
