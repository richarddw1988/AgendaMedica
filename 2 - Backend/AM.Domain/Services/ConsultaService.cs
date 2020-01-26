using AM.Domain.Entities;
using AM.Domain.Exceptions;
using AM.Domain.Interface.Repository;

namespace AM.Domain.Services
{
    public class ConsultaService 
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public void CriarConsulta(ConsultaEntity consultaEntity)
        {
            ValidarCriacao(consultaEntity);
            _consultaRepository.Add(consultaEntity);
        }

        public void ValidarCriacao(ConsultaEntity consultaEntity)
        {
            if(_consultaRepository.ExisteConsulta(consultaEntity.DataHoraInicio, consultaEntity.DataHoraFinal))
            {
                throw new BusinessException("Já existe consulta marcada para a data e horário.");
            }
        }
    }
}
