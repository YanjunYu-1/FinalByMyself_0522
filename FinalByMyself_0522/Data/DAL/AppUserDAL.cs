using FinalByMyself_0522.Models;

namespace FinalByMyself_0522.Data.DAL
{
    public class AppUserDAL : IDAL<AppUser>
    {
        public ApplicationDbContext Context { get; set; }
        public AppUserDAL(ApplicationDbContext context)
        {
            Context = context;
        }

        //Create
        public void Add(AppUser entity)
        {
            Context.AppUser.Add(entity);//Q?Context.Add(appuser);
        }

        //Read

        //此方法是后期加上去的，前面IDAL中没有
        public AppUser GetById(string id)
        {
            return Context.AppUser.First(x => x.Id == id);
        }

        public AppUser Get(Func<AppUser, bool> firstFuction)
        {
            return Context.AppUser.First(firstFuction);
        }

        public ICollection<AppUser> GetAll()
        {
            return Context.AppUser.ToList();
        }

        public ICollection<AppUser> GetList(Func<AppUser, bool> whereFuction)
        {
            return Context.AppUser.Where(whereFuction).ToList();
        }

        public void Update(AppUser entity)
        {
            Context.AppUser.Update(entity);
        }

        public void Delete(AppUser entity)
        {
            Context.AppUser.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
