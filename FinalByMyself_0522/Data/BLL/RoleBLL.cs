using FinalByMyself_0522.Data.DAL;
using Microsoft.AspNetCore.Identity;

namespace FinalByMyself_0522.Data.BLL
{
    public class RoleBLL
    {
        public RoleDAL repo;
        public RoleBLL(RoleDAL repoPb)
        {
            this.repo = repoPb;
        }

        public void Add(IdentityRole entity)
        {
            repo.Add(entity);
        }
        public IdentityRole Get(Func<IdentityRole, bool> firstFuction)
        {
            return repo.Get(firstFuction);
        }
        public ICollection<IdentityRole> GetAll()
        {
            return repo.GetAll();
        }
        public ICollection<IdentityRole> GetList(Func<IdentityRole, bool> whereFuction)
        {
            return repo.GetList(whereFuction);
        }

        public void Update(IdentityRole entity)
        {
            repo.Update(entity);
        }
        public void Save()
        {
            repo.Save();
        }
    }
}
