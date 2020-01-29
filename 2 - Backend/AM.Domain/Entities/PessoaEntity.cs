using System;
using System.Collections.Generic;

namespace AM.Domain.Entities
{
    public class PessoaEntity : Entity
    {
        public PessoaEntity()
        {
            Consultas = new HashSet<ConsultaEntity>();
        }

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public IEnumerable<ConsultaEntity> Consultas { get; set; }
    }
}
