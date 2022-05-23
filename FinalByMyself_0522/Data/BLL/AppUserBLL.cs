using FinalByMyself_0522.Data.DAL;
using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.BLL
{
    public class AppUserBLL
    {
        //IDAL<AppUser> repo;//里面有AppUserDAL没有的function

        public AppUserDAL repo;
        //public UserManager<AppUser> userManager;
        public AppUserBLL(AppUserDAL repoAub)
        {
            this.repo = repoAub;
        }
        public void Add(AppUser entity)
        {
            repo.Add(entity);
        }
        public AppUser Get(Func<AppUser, bool> firstFuction)
        {
            return repo.Get(firstFuction);
        }
        public ICollection<AppUser> GetAll()
        {
            return repo.GetAll();
        }
        public ICollection<AppUser> GetList(Func<AppUser, bool> whereFuction)
        {
            return repo.GetList(whereFuction);
        }

        public void Update(AppUser entity)
        {
            repo.Update(entity);
        }
        public void Save()
        {
            repo.Save();
        }

        //public AppUserBLL(AppUserDAL adal)
        //{ 
        //    AppUserDAL = adal; 
        //}


        //public AppUser GetUserById(string Id)
        //{
        //    return AppUserDAL.GetById(Id);
        //}

    }
}
