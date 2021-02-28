using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace starting_with_aspnetcore.Models
{
    public class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
        
        [Required]
        [Column(TypeName = "varchar(16)")]
        public Guid Id { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdatedAt { get; set; }
    }
}