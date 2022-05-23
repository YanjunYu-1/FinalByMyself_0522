using FinalByMyself_0522.Data.DAL;
using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.BLL
{
    public class ProjectBLL
    {
        public ProjectDAL repo;
        public ProjectBLL(ProjectDAL repoPb)
        {
            this.repo = repoPb;
        }

        public Project GetById(int id)
        {
            return repo.Get(id);
        }
        public void Add(Project entity)
        {
            repo.Add(entity);
        }
        public Project Get(Func<Project, bool> firstFuction)
        {
            return repo.Get(firstFuction);
        }
        public ICollection<Project> GetAll()
        {
            return repo.GetAll();
        }
        public ICollection<Project> GetList(Func<Project, bool> whereFuction)
        {
            return repo.GetList(whereFuction);
        }

        public void Update(Project entity)
        {
            repo.Update(entity);
        }
        public void Save()
        {
            repo.Save();
        }
    }
}
