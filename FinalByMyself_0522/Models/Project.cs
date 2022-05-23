namespace FinalByMyself_0522.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //One(Project) To Many
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }
        public Project()
        {
            Tickets = new HashSet<Ticket>();
            ProjectUsers = new HashSet<ProjectUser>();
        }
    }
}
