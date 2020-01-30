using AM.Domain.Entities;
using System;
using System.Linq;

namespace AM.Domain.Interface.Repository
{
    public interface IConsultaRepository : IRepository<ConsultaEntity>
    {
        bool ExisteConsulta(DateTime dataHoraInicio, DateTime dataFinal);
        ConsultaEntity GetConsultaPacienteById(int id);
        void DeleteConsultaPacienteById(int id);
        void AtualizarConsultaPacienteById(int id, ConsultaEntity consultaEntity);
    }
}
