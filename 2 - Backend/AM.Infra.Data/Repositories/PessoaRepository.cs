using AM.Domain.Entities;
using AM.Domain.Interface.Repository;
using AM.Infra.Data.Context;

namespace AM.Infra.Data.Repositories
{
    public class PessoaRepository : Repository<PessoaEntity>, IPessoaRepository
    {
        public PessoaRepository(AppDbContext context) : base(context) { }
    }
}
