using System;
using System.ComponentModel.DataAnnotations;

namespace AM.Domain.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            DataCriacao = DateTime.Now;
        }

        public int Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAtualizacao { get; private set; }

        public void ModifiedEntity()
        {
            DataAtualizacao = DateTime.Now;
        }
    }
}
