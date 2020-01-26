using AutoMapper;
using AM.App.ViewModel;
using AM.Domain.Entities;

namespace AM.App.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ConsultaEntity, ConsultaModel>();
            CreateMap<PessoaEntity, ConsultaModel>();
        }
    }
}
