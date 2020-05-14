using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.UserModels
{
    public class UserForList
    {
        [ForeignKey("Id")]
        public int Id { get; set; }
        public string Username { get; set; }
        public byte Role { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
    }
}
