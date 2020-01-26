using AM.Domain.Entities;
using System;

namespace AM.Domain.Entities
{
    public class ConsultaEntity : Entity
    {
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFinal { get; set; }
        public string Observacoes { get; set; }
        public int IdPessoa { get; set; }
        public PessoaEntity Paciente { get; set; }
    }
}
