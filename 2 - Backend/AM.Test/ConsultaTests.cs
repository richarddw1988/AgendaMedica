using AM.App.ViewModel;
using AM.Service;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AM.UnitTests
{
    public class ConsultaTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient _client;
        private readonly WebApplicationFactory<Startup> _factory;


        public ConsultaTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            var options = new WebApplicationFactoryClientOptions { AllowAutoRedirect = false };
            _client = _factory.CreateClient(options);
        }

        [Fact]
        public async Task ValidarInserirConsultaAsync()
        {
            var consultaModel1 = new ConsultaModel()
            {
                DataHoraInicio = new DateTime(2020, 01, 01, 1, 0, 0),
                DataHoraFinal = new DateTime(2020, 01, 01, 1, 30, 0),
                Pessoa = new PessoaModel()
                {
                    DataNascimento = new DateTime(1988, 06, 05),
                    Nome = "Richardd Nunes Mattos"
                }
            };

            var json = JsonConvert.SerializeObject(consultaModel1.Pessoa);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            // Arrange
            var request = "/api/Consulta";

            // Act
            var response = await _client.PostAsync(request, data);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string result = response.Content.ReadAsStringAsync().Result;
            Assert.NotEmpty(result);

            var consultaModel2 = new ConsultaModel()
            {
                DataHoraInicio = new DateTime(2020, 01, 01, 1, 0, 0),
                DataHoraFinal = new DateTime(2020, 01, 01, 1, 30, 0),
                Pessoa = new PessoaModel()
                {
                    DataNascimento = new DateTime(1988, 06, 05),
                    Nome = "João Batista"
                }
            };

            json = JsonConvert.SerializeObject(consultaModel2);
            data = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            response = await _client.PostAsync(request, data);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            response.Dispose();

        }
    }
}
