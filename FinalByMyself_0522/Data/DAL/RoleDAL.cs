using Microsoft.AspNetCore.Identity;

namespace FinalByMyself_0522.Data.DAL
{
    public class RoleDAL : IDAL<IdentityRole>
    {
        public ApplicationDbContext Context { get; set; }
        public RoleDAL(ApplicationDbContext context)
        {
            Context = context;
        }

        //Create
        public void Add(IdentityRole entity)
        {
            Context.Roles.Add(entity);//Q?Context.Add(IdentityRole);
        }

        //Read

        //此方法是后期加上去的，前面IDAL中没有
        public IdentityRole GetById(string id)
        {
            return Context.Roles.First(x => x.Id == id);
        }

        public IdentityRole Get(Func<IdentityRole, bool> firstFuction)
        {
            return Context.Roles.First(firstFuction);
        }

        public ICollection<IdentityRole> GetAll()
        {
            return Context.Roles.ToList();
        }

        public ICollection<IdentityRole> GetList(Func<IdentityRole, bool> whereFuction)
        {
            return Context.Roles.Where(whereFuction).ToList();
        }

        public void Update(IdentityRole entity)
        {
            Context.Roles.Update(entity);
        }

        public void Delete(IdentityRole entity)
        {
            Context.Roles.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
