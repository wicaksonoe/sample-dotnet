using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Models
{
    [Table("Users")]
    public class User
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("username")]
        [Required(ErrorMessage = "Username cannot be empty")]
        [StringLength(10, ErrorMessage = "Username cannot longer than 10 characters")]
        public string Username { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "Email cannot be empty")]
        [StringLength(100)]
        public string Email { get; set; }

        [Column("password")]
        [Required(ErrorMessage = "Password cannot be empty")]
        [MinLength(8, ErrorMessage = "Password should longer than 9 characters")]
        public string Password { get; set; }

        public Profile Profile { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<UserTag> UserTags { get; set; }
    }
}
