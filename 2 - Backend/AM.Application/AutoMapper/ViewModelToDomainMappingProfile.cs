using AutoMapper;
using DDDCore.App.ViewModel;
using DDDCore.Domain.Models;

namespace DDDCore.App.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
          CreateMap<UserModel, UserEntity>();
        }
    }
}
