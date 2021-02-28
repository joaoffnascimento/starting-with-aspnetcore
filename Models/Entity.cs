using System;

namespace starting_with_aspnetcore.Models
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            createdAt = DateTime.Now;
            createdAt = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}