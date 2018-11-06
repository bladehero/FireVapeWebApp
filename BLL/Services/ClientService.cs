using BLL.DTO;
using BLL.Interfaces;
using DAL.Identities;
using System;
using System.Text;

namespace BLL.Services
{
    public class ClientService : BaseService, IAccountService
    {
        public ClientService(string connectionString) : base(connectionString) { }

        public ClientDTO Client { get; set; }
        public bool IsAuthorized => Client == null;
        public void SignUp(ClientDTO client)
        {
            Login(IdentityMapper.Map(client));
        }
        public ClientDTO Authorize(string username, string password)
        {
            Login(Database.Clients.FindByCredentials(username, GetHashPassword(password)));
            return Client;
        }
        public ClientDTO Authenticate(string token)
        {
            var client = Database.Clients.FindByToken(token);
            Client = null;
            if (client != null)
            {
                Client = IdentityMapper.MapToDTO(client);
            }
            return Client;
        }
        public void Logout()
        {
            if (Client == null)
            {
                return;
            }
            Client.Token = null;
            Database.Clients.Update(IdentityMapper.Map(Client));
        }
        public bool HasPermission(RoleType role)
        {
            if (Client != null)
            {
                return Client.Role.Name == role.ToString().ToLower();
            }
            return false;
        }

        #region Helpers
        private string GetHashPassword(string password, string salt = "")/*"0de$$aF!r3Vap3"*/
        {
            password = password + salt;
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        private string CreateToken(ClientDTO client, string salt)
        {
            string token = client.Phone + client.Login;
            return GetHashPassword(token, salt);
        }
        private void Login(Client client)
        {
            if (client == null)
            {
                Client = null;
                return;
            }
            var now = DateTime.Now;
            Client = IdentityMapper.MapToDTO(client);
            Client.Token = CreateToken(Client, now.ToLongTimeString() + now.ToLongDateString());
            Client.LoginDate = now;
            if (Database.Clients.FindById(client.Id) == null)
            {
                Database.Clients.Insert(IdentityMapper.Map(Client));
            }
            else
            {
                Database.Clients.Update(IdentityMapper.Map(Client));
            }
        }
        #endregion
    }
}
