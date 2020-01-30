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
            if(consultaEntity.DataHoraInicio > consultaEntity.DataHoraFinal)
            {
                throw new BusinessException("A data inicial da consulta não pode ser maior que a final.");
            }

            var exists = _consultaRepository.ExisteConsulta(consultaEntity.Id, consultaEntity.DataHoraInicio, consultaEntity.DataHoraFinal);

            if (exists)
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
