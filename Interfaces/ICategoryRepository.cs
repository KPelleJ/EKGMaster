using EKGMaster.Models.ProductStuff;

namespace EKGMaster.Interfaces
{
    public interface ICategoryRepository<T>
    {
        public List<Product> GetAll();

        public Product GetOne(T t);

        public void Add(T t);

        public void Update(T t);

        public void Delete(T t);
    }
}
