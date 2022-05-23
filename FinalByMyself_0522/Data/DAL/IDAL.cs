namespace FinalByMyself_0522.Data.DAL
{
    public interface IDAL<T> where T : class
    {
        //Create
        void Add(T entity);

        //Read
        //T GetById(T id);//自己加的（尝试中）如果有就会产生错误
        T Get(Func<T, bool> firstFuction);
        ICollection<T> GetAll();
        ICollection<T> GetList(Func<T, bool> whereFuction);

        //Update
        void Update(T entity);

        //Delete
        void Delete(T entity);
        void Save();
    }
}
