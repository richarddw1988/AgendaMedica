using AutoMapper;
using AM.App.ViewModel;
using AM.Domain.Entities;

namespace AM.App.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PessoaEntity, PessoaModel>();
            CreateMap<ConsultaEntity, ConsultaModel>();
        }
    }
}
