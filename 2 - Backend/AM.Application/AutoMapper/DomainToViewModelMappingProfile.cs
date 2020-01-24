using AutoMapper;
using AM.App.ViewModel;
using AM.Domain.Models;

namespace AM.App.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<UserEntity, UserModel>();
        }
    }
}
