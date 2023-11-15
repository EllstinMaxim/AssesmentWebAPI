using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Users")]

    public class Users
    {
        [Key]
        public int userId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string skillsets { get; set; }
        public string hobby { get; set; }

    }
}
