using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace starting_with_aspnetcore.Models
{
    public class Repository : Entity
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        public ICollection<Tech> Techs { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Stars { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string About { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
    }
}