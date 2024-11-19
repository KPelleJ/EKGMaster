using EKGMaster.Interfaces;
using EKGMaster.Models.UserStuff;

namespace EKGMaster.Repositories
{
    public class CredentialRepository : ICRUDRepository<Credential>
    {
        private readonly string _connectionString;

        public CredentialRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("myDb1");
        }

        public void Add(Credential t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Credential t)
        {
            throw new NotImplementedException();
        }

        public List<Credential> GetAll()
        {
            throw new NotImplementedException();
        }

        public Credential GetSingleObject(Credential t)
        {
            throw new NotImplementedException();
        }

        public void Update(Credential t)
        {
            throw new NotImplementedException();
        }
    }
}
