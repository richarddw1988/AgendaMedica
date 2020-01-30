using AutoMapper;
using AM.App.ViewModel;
using AM.Domain.Entities;
using System.Collections.Generic;

namespace AM.App.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PessoaModel, PessoaEntity>();
            CreateMap<ConsultaModel, ConsultaEntity>();
        }
    }
}
