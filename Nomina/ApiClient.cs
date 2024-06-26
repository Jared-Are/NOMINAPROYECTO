using SharedModels.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SharedModels;

namespace Nomina
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        public IRepository<EmpleadoDto> Empleados { get; }
        public IRepository<IngresoDto> Ingresos { get; }
        public IRepository<DeduccionDto> Deducciones { get; }
        public IUserRepository LoginUsers { get; }
        public ApiClient()
        {
            string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            _httpClient = new HttpClient { BaseAddress = new Uri(apiBaseUrl)};
            Empleados = new Repository<EmpleadoDto>(_httpClient, "Empleados");
            Ingresos = new Repository<IngresoDto>(_httpClient, "Ingresos");
            Deducciones = new Repository<DeduccionDto>(_httpClient, "Deducciones");
            LoginUsers = new UserRepository(_httpClient, "Auth/Login");
        }

        /*public void SetAuthToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }*/
    }
}
