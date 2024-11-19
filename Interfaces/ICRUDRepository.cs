namespace EKGMaster.Interfaces
{
    public interface ICRUDRepository<T>
    {
        public T GetSingleObject(T t);
        public List<T> GetAll();
        public void Delete(T t);
        public void Update(T t);
        public void Add(T t);
    }
}
