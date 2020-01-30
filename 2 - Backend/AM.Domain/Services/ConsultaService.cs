using System;
using AM.Domain.Entities;
using AM.Domain.Exceptions;
using AM.Domain.Interface.Repository;

namespace AM.Domain.Services
{
    public class ConsultaService 
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IPessoaRepository _pessoaRepository;

        public ConsultaService(IConsultaRepository consultaRepository, IPessoaRepository pessoaRepository)
        {
            _consultaRepository = consultaRepository;
            _pessoaRepository = pessoaRepository;
        }

        public void CriarConsulta(ConsultaEntity consultaEntity)
        {
            ValidarSalvar(consultaEntity);
            _consultaRepository.Add(consultaEntity);
            _consultaRepository.SaveChanges();
        }

        public void ValidarSalvar(ConsultaEntity consultaEntity)
        {
            if(_consultaRepository.ExisteConsulta(consultaEntity.DataHoraInicio, consultaEntity.DataHoraFinal))
            {
                throw new BusinessException("Já existe consulta marcada para a data e horário.");
            }
        }

        public void AtualizarConsulta(int id, ConsultaEntity consultaEntity)
        {
            ValidarSalvar(consultaEntity);

            _consultaRepository.AtualizarConsultaPacienteById(id, consultaEntity);
            _consultaRepository.SaveChanges();
        }
    }
}
