using DAL.Identities;
using System;
using System.Linq;

namespace DAL.DAO
{
    public class ClientDao : BaseEntityDao<Client>
    {
        public ClientDao(string connectionString) : base(connectionString)
        {
            TableName = "[dbo].[Clients]";
        }

        public Client FindByCredentials(string username, string password)
        {
            return FindAll(c => c.Login == username && c.Password == password).FirstOrDefault();
        }
        public Client FindByToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return null;
            }
            return FindAll(c => c.Token == token).FirstOrDefault();
        }
        public override long Insert(Client entity)
        {
            entity.LoginDate = DateTime.Now;
            return base.Insert(entity);
        }
    }
}
