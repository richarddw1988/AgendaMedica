using AM.App.AutoMapper;
using AM.App.Services;
using AM.App.ViewModel;
using AM.Domain.Entities;
using AM.Domain.Services;
using AM.Infra.Data.Context;
using AM.Infra.Data.Repositories;
using AM.Service;
using AM.Service.Controllers;
using AM.UnitTests;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http;
using Xunit;

namespace AM.Test
{
    public class CriarConsulta 
    {
        public CriarConsulta()
        {
            InitContext();
        }

        private AppDbContext _context;

        public void InitContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=DESKTOP-9KK5DU4\\SQLEXPRESS;Database=AgendaMedica;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            _context = new AppDbContext(options);
        }


        [Fact]
        public void Validar_Criacao_De_Consulta_Com_Uma_Ja_Existente()
        {

     
            //InitContext();
            var _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });

            var mapper = _mapper.CreateMapper();

            var consultaRepository = new ConsultaRepository(_context);
            //var consultaAppService = new ConsultaAppService(mapper, consultaRepository);
            var consultaService = new ConsultaService(consultaRepository);

            consultaService.CriarConsulta(new ConsultaEntity());

            var consultaModel1 = new ConsultaModel()
            {
                DataHoraInicio = new DateTime(2020, 01, 01, 1, 0, 0),
                DataHoraFinal = new DateTime(2020, 01, 01, 1, 30, 0),
                Paciente = new PessoaModel()
                {
                    DataNascimento = new DateTime(1988, 06, 05),
                    Nome = "Richardd Nunes Mattos"
                }
            };

            var consultaModel2 = new ConsultaModel()
            {
                DataHoraInicio = new DateTime(2020, 01, 01, 1, 0, 0),
                DataHoraFinal = new DateTime(2020, 01, 01, 1, 30, 0),
                Paciente = new PessoaModel()
                {
                    DataNascimento = new DateTime(1988, 06, 05),
                    Nome = "João Batista"
                }
            };

            //consultaRepository.Add(consultaModel1);

        }
    }
}
