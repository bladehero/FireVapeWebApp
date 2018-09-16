using System;

namespace DAL.Identities
{
    public class Client : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public double Sale { get; set; }
        public double TotalPurchases { get; set; }

        public DateTime LoginDate { get; set; }
        public string Token { get; set; }
    }
}
