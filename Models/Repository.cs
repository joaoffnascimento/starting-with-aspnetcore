using System.Collections.Generic;

namespace starting_with_aspnetcore.Models
{
    public class Repository : Entity
    {
        public string Title { get; set; }
        public ICollection<Tech> Techs { get; set; }
        public int Stars { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
    }
}