using System;
using System.Collections.Generic;

namespace AM.App.ViewModel
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<ConsultaModel> Consultas { get; set; }
    }
}
