using AM.Domain.Entities;
using System;

namespace AM.Domain.Interface.Repository
{
    public interface IConsultaRepository : IRepository<ConsultaEntity>
    {
        bool ExisteConsulta(DateTime dataHoraInicio, DateTime dataFinal);
    }
}
