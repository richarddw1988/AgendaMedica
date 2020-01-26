using AM.Infra.Data.Context;
using AM.Domain.Interface;
using AM.Domain.Entities;

namespace AM.Infra.Data.Repositories
{
    public class ConsultaRepository : Repository<ConsultaEntity>, IConsultaRepository
    {
        public ConsultaRepository(AppDbContext context) : base(context) { }
    }
}
