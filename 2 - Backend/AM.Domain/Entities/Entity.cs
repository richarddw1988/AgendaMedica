using System;
using System.ComponentModel.DataAnnotations;

namespace AM.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
