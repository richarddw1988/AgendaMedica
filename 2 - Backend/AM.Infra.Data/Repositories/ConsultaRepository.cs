using AM.Infra.Data.Context;
using AM.Domain.Entities;
using AM.Domain.Interface.Repository;
using System;
using System.Linq;

namespace AM.Infra.Data.Repositories
{
    public class ConsultaRepository : Repository<ConsultaEntity>, IConsultaRepository
    {
        public ConsultaRepository(AppDbContext context) : base(context) { }

        public bool ExisteConsulta(DateTime dataHoraInicio, DateTime dataHoraFinal)
        {
            return Db.Consulta.Where(c => c.DataHoraInicio >= dataHoraInicio && c.DataHoraFinal <= dataHoraFinal).Any(); 
        }
    }
}
