using System.Collections.Generic;

namespace BLL.Models
{
    public class User
    {
        public const byte ADMIN = 4;
        public const byte MANAGER = 3;
        public const byte AUTHORIZED = 2;
        public const byte UN_AUTHORIZED = 1;

        public int Id { get; set; }
        public byte Role { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordKey { get; set; }
        public string Address { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
