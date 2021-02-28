using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace starting_with_aspnetcore.Models
{
    public class Tech : Entity
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string name {get; set; }
    }
}