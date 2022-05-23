using FinalByMyself_0522.Data.DAL;
using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.BLL
{
    public class ProjectUserBLL
    {
        public ProjectUserDAL projectUserDAL;
        public ProjectUserBLL(ProjectUserDAL projectUserDALAub)
        {
            this.projectUserDAL = projectUserDALAub;
        }
        public void Add(ProjectUser entity)
        {
            projectUserDAL.Add(entity);
        }
        public ProjectUser Get(Func<ProjectUser, bool> firstFuction)
        {
            return projectUserDAL.Get(firstFuction);
        }
        public ICollection<ProjectUser> GetAll()
        {
            return projectUserDAL.GetAll();
        }
        public ICollection<ProjectUser> GetList(Func<ProjectUser, bool> whereFuction)
        {
            return projectUserDAL.GetList(whereFuction);
        }
        public void Update(ProjectUser entity)
        {
            projectUserDAL.Update(entity);
        }
        public void Save()
        {
            projectUserDAL.Save();
        }
    }
}
