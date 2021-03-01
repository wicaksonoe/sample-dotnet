using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Models
{
    [Table("profiles")]
    public class Profile
    {
        [Column("id"),
        Key,
        DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("user_id"),
        Required(ErrorMessage = "User_id cannot be empty")]
        public long UserId { get; set; }

        [Column("name"),
        Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [Column("date_of_birth"),
        Required(ErrorMessage = "Date of birth cannot be empty")] 
        public DateTime DateOfBirth { get; set; }

        [Column("telp"),
        Required(ErrorMessage = "Telephone number cannot be empty")] 
        public string Telp { get; set; }

        [Column("address"),
        Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }

        public User User { get; set; }
    }
}
