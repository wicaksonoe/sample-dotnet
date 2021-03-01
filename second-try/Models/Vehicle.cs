using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Models
{
    [Table("vehicles")]
    public class Vehicle
    {
        [Column("id"),
        Key,
        DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("user_id"),
        Required(ErrorMessage = "User ID cannot be empty")]
        public long UserId { get; set; }

        [Column("name"),
        Required(ErrorMessage = "Vehicle name cannot be empty"),
        MaxLength(50, ErrorMessage = "Vehicle name cannot longer than 50 characters")]
        public string Name { get; set; }

        [Column("type"),
        Required(ErrorMessage = "Type cannot be empty"),
        MaxLength(10, ErrorMessage = "Type cannot longer than 10 characters")]
        public string Type { get; set; }

        public User User { get; set; }
    }
}
