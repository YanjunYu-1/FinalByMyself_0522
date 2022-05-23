namespace FinalByMyself_0522.Models
{
    public class ProjectUser
    {
        public int Id { get; set; }

        //Many(ProjectUser) To One
        public string UserId { get; set; }
        public AppUser? User { get; set; }

        public int ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
