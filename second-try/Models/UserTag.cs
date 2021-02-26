using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Models
{
    [Table("user_tags")]
    public class UserTag
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("user_id")]
        [Required(ErrorMessage = "User ID cannot be empty")]
        public long UserId { get; set; }

        [Column("tag_id")]
        [Required(ErrorMessage = "Tag ID cannot be empty")]
        public long TagId { get; set; }

        public User User { get; set; }
        public Tag Tag { get; set; }
    }
}
