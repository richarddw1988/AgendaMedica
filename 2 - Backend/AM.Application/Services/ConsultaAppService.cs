using AutoMapper;
using AM.App.ViewModel;
using System;
using AutoMapper.QueryableExtensions;
using System.Linq;
using AM.Domain.Interface;
using AM.Domain.Entities;

namespace AM.App.Services
{
    public class ConsultaAppService
  {
    private readonly IMapper _mapper;
    private readonly IConsultaRepository _userRepository;

    public ConsultaAppService(IMapper mapper, IConsultaRepository userRepository)
    {
      _mapper = mapper;
      _userRepository = userRepository;
    }

    public IQueryable<ConsultaModel> GetAll()
    {
      return _userRepository.GetAll().ProjectTo<ConsultaModel>(_mapper.ConfigurationProvider);
    }

    public ConsultaModel GetById(int id)
    {
      return _mapper.Map<ConsultaModel>(_userRepository.GetById(id));
    }

    public void Insert(ConsultaModel userModel)
    {
      _userRepository.Add(_mapper.Map<ConsultaEntity>(userModel));
      _userRepository.SaveChanges();
    }

    public void Update(int id, ConsultaModel userModel)
    {
      _userRepository.Update(id, _mapper.Map<ConsultaEntity>(userModel));
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
