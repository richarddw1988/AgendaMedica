using AutoMapper;
using AM.App.ViewModel;
using AM.Domain.Models;

namespace AM.App.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
          CreateMap<UserModel, UserEntity>();
        }
    }
}
