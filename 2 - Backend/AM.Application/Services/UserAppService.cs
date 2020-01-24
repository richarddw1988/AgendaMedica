using AutoMapper;
using AM.App.ViewModel;
using System;
using AutoMapper.QueryableExtensions;
using System.Linq;
using AM.Domain.Interface;
using AM.Domain.Models;

namespace AM.App.Services
{
  public class UserAppService
  {
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserAppService(IMapper mapper, IUserRepository userRepository)
    {
      _mapper = mapper;
      _userRepository = userRepository;
    }

    public IQueryable<UserModel> GetAll()
    {
      return _userRepository.GetAll().ProjectTo<UserModel>(_mapper.ConfigurationProvider);
    }

    public UserModel GetById(int id)
    {
      return _mapper.Map<UserModel>(_userRepository.GetById(id));
    }

    public void Insert(UserModel userModel)
    {
      _userRepository.Add(_mapper.Map<UserEntity>(userModel));
      _userRepository.SaveChanges();
    }

    public void Update(int id, UserModel userModel)
    {
      _userRepository.Update(id, _mapper.Map<UserEntity>(userModel));
      _userRepository.SaveChanges();
    }

    public void Remove(int id)
    {
      var obj = _userRepository.GetById(id);
      _userRepository.Remove(obj);
      _userRepository.SaveChanges();
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
