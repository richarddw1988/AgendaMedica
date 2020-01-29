using System;
using System.Collections.Generic;

namespace AM.App.ViewModel
{
    public class PessoaModel
    {
        public PessoaModel()
        {
            Consultas = new HashSet<ConsultaModel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public IEnumerable<ConsultaModel> Consultas { get; set; }
    }
}
