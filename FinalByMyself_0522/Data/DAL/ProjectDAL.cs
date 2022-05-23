using FinalByMyself_0522.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalByMyself_0522.Data.DAL
{
    public class ProjectDAL : IDAL<Project>
    {
        public ApplicationDbContext Context { get; set; }
        public ProjectDAL(ApplicationDbContext context)
        {
            Context = context;
        }

        //Create
        public void Add(Project entity)
        {
            Context.Project.Add(entity);
        }

        //Read
        public Project Get(int id)
        {
            var projects = Context.Project.Include(p => p.Tickets);
            return projects.First(a => a.Id == id); ;
        }
        public Project Get(Func<Project, bool> firstFuction)
        {
            return Context.Project.First(firstFuction);
        }

        public ICollection<Project> GetAll()
        {
            return Context.Project.ToList();
        }

        public ICollection<Project> GetList(Func<Project, bool> whereFuction)
        {
            return Context.Project.Where(whereFuction).ToList();
        }

        //Update
        public void Update(Project entity)
        {
            Context.Project.Update(entity);
        }

        //Delete
        public void Delete(Project entity)
        {
            Context.Project.Remove(entity);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
