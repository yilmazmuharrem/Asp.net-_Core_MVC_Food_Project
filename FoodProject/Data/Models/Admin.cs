using System.ComponentModel.DataAnnotations;

namespace FoodProject.Data.Models
{
    public class Admin
    {

        [Key]

        public int AdminId { get; set; }


        [StringLength(20)]
        public string Username { get; set; }

        [StringLength(20)]

        public string Password { get; set; }

        [StringLength(1)]

        public string AdminRole { get; set; }
    }
}
