using System;

namespace AM.Domain.Entities
{
    public class PessoaEntity : Entity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
