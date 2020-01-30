using AM.Infra.Data.Context;
using AM.Domain.Entities;
using AM.Domain.Interface.Repository;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AM.Infra.Data.Repositories
{
    public class ConsultaRepository : Repository<ConsultaEntity>, IConsultaRepository
    {
        private IPessoaRepository _pessoaRepository;
        public ConsultaRepository(AppDbContext context, IPessoaRepository pessoaRepository) : base(context)
        {
            _pessoaRepository = pessoaRepository;
        }

        public void DeleteConsultaPacienteById(int id)
        {
            var consultaEntity = Db.Consulta.Where(c => c.Id == id).FirstOrDefault();
            var pessoaEntity = Db.Pessoa.Where(p => p.Id == consultaEntity.IdPessoa).FirstOrDefault();
            _pessoaRepository.Remove(pessoaEntity);
            Remove(consultaEntity);
        }

        public bool ExisteConsulta(DateTime dataHoraInicio, DateTime dataHoraFinal)
        {
            return Db.Consulta.Where(c => c.DataHoraInicio >= dataHoraInicio && c.DataHoraFinal <= dataHoraFinal).Any();
        }

        public ConsultaEntity GetConsultaPacienteById(int id)
        {
            return Db.Consulta.Include("Pessoa").Where(c => c.Id == id).FirstOrDefault();
        }

        public void AtualizarConsultaPacienteById(int id, ConsultaEntity consultaEntity)
        {
            var consultaEntityOld = Db.Consulta.Include("Pessoa").Where(c => c.Id == id).FirstOrDefault();
            consultaEntityOld.Observacoes = consultaEntity.Observacoes;
            consultaEntityOld.DataHoraFinal = consultaEntity.DataHoraFinal;
            consultaEntityOld.DataHoraInicio = consultaEntity.DataHoraInicio;
            consultaEntityOld.Pessoa.Nome = consultaEntity.Pessoa.Nome;
            consultaEntityOld.Pessoa.DataNascimento = consultaEntity.Pessoa.DataNascimento;
        }

    }
}
