using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace second_try.Models
{
    [Table("tags")]
    public class Tag
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Tag name cannot be empty")] 
        [MaxLength(10, ErrorMessage = "Tag name cannot longer than 10 characters")]
        public string Name { get; set; }

        public ICollection<UserTag> UserTags { get; set; }
    }
}
