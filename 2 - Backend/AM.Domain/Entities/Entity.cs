using System;
using System.ComponentModel.DataAnnotations;

namespace AM.Domain.Entities
{
    public abstract class Entity
    { 
        public int Id { get; private set; }
    }
}
