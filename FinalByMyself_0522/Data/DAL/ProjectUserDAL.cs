using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.DAL
{
    public class ProjectUserDAL : IDAL<ProjectUser>
    {
        public ApplicationDbContext Context { get; set; }
        public ProjectUserDAL(ApplicationDbContext context)
        {
            Context = context;
        }

        //Creat
        public void Add(ProjectUser entity)
        {
            Context.ProjectUser.Add(entity);
        }

        //Read
        public ProjectUser Get(int id)
        {
            return Context.ProjectUser.First(x => x.Id == id);
        }

        public ProjectUser Get(Func<ProjectUser, bool> firstFuction)
        {
            return Context.ProjectUser.First(firstFuction);
        }

        public ICollection<ProjectUser> GetAll()
        {
            return Context.ProjectUser.ToList();
        }

        public ICollection<ProjectUser> GetList(Func<ProjectUser, bool> whereFuction)
        {
            return Context.ProjectUser.Where(whereFuction).ToList();
        }

        public void Update(ProjectUser entity)
        {
            Context.ProjectUser.Update(entity);
        }

        public void Delete(ProjectUser entity)
        {
            Context.ProjectUser.Remove(entity);
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
