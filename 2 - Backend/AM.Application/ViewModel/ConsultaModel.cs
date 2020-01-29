using System;

namespace AM.App.ViewModel
{
    public class ConsultaModel
    {
        public int Id { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFinal { get; set; }
        public string Observacoes { get; set; }
        public int IdPessoa { get; set; }
        public PessoaModel Pessoa { get; set; }
    }
}
