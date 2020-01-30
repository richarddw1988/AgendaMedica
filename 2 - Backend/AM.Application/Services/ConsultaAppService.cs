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

        public ConsultaAppService(IMapper mapper, IConsultaRepository consultaRepository, ConsultaService consultaService)
        {
            _mapper = mapper;
            _consultaRepository = consultaRepository;
            _consultaService = consultaService;
        }

        public IQueryable<ConsultaModel> GetAll()
        {
            return _consultaRepository.GetAll().ProjectTo<ConsultaModel>(_mapper.ConfigurationProvider);
        }

        public ConsultaModel GetById(int id)
        {
            var consulta = _mapper.Map<ConsultaModel>(_consultaRepository.GetConsultaPacienteById(id));
            //O automapper não estava ignorando a lista de jeito nenhum
            consulta.Pessoa.Consultas = null;
            return consulta;
        }

        public void Insert(ConsultaModel consultaModel)
        {
            _consultaService.CriarConsulta(_mapper.Map<ConsultaEntity>(consultaModel));
        }

        public void Update(int id, ConsultaModel consultaModel)
        {
            _consultaService.AtualizarConsulta(id, _mapper.Map<ConsultaEntity>(consultaModel));        
        }

        public void Remove(int id)
        {
            _consultaRepository.DeleteConsultaPacienteById(id);
            _consultaRepository.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
