using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        ClientDTO Client { get; set; }
        void SignUp(ClientDTO client);
        ClientDTO Authorize(string username, string password);
        ClientDTO Authenticate(string token);
        void Logout();
        bool HasPermission(RoleType role);
        bool IsAuthorized { get; }
    }

    public enum RoleType
    {
        Admin,
        Client
    }
}
