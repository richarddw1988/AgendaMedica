using AutoMapper;
using AM.App.ViewModel;
using System;
using AutoMapper.QueryableExtensions;
using System.Linq;
using AM.Domain.Entities;
using AM.Domain.Interface.Repository;
using AM.Domain.Services;

namespace AM.App.Services
{
    public class ConsultaAppService
    {
        private readonly IMapper _mapper;
        private readonly IConsultaRepository _consultaRepository;
        private ConsultaService _consultaService;

        public ConsultaAppService(IMapper mapper, IConsultaRepository consultaRepository)
        {
            _mapper = mapper;
            _consultaRepository = consultaRepository;
        }

        public IQueryable<ConsultaModel> GetAll()
        {
            return _consultaRepository.GetAll().ProjectTo<ConsultaModel>(_mapper.ConfigurationProvider);
        }

        public ConsultaModel GetById(int id)
        {
            return _mapper.Map<ConsultaModel>(_consultaRepository.GetById(id));
        }

        public void Insert(ConsultaModel consultaModel)
        {
            _consultaService.CriarConsulta(_mapper.Map<ConsultaEntity>(consultaModel));
        }

        public void Update(int id, ConsultaModel consultaModel)
        {
            _consultaRepository.Update(id, _mapper.Map<ConsultaEntity>(consultaModel));
            _consultaRepository.SaveChanges();
        }

        public void Remove(int id)
        {
            var obj = _consultaRepository.GetById(id);
            _consultaRepository.Remove(obj);
            _consultaRepository.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
