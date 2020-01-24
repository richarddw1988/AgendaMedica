using AutoMapper;
using DDDCore.App.ViewModel;
using DDDCore.Domain.Models;

namespace DDDCore.App.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<UserEntity, UserModel>();
        }
    }
}
