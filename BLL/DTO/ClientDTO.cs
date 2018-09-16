using System;

namespace BLL.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public RoleDTO Role { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public double Sale { get; set; }
        public double TotalPurchases { get; set; }

        public string Token { get; set; }
        public DateTime LoginDate { get; set; }
    }
}
