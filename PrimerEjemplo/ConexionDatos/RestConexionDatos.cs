using PrimerEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PrimerEjemplo.ConexionDatos
{
    public class RestConexionDatos : IRestConexionDatos
    {
        public readonly HttpClient httpClient;
        private readonly string dominio;
        private readonly string url;
        private readonly JsonSerializerOptions opcionesJson;
        public RestConexionDatos()
        {
            httpClient = new HttpClient();
            //dominio = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7169" : "https://localhost:7169";
            dominio = "https://localhost:7169";
            url = $"{dominio}/api";
            opcionesJson = new JsonSerializerOptions { 
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        public Task AddPlatoAsync(Plato plato)
        {
            throw new NotImplementedException();
        }

        public Task DeletePlatoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Plato>> GetPlatosAsync()
        {
            List<Plato> platos = new List<Plato>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("[RED] Sin acceso a internet.");
                return platos;
            }
        }

        public Task UpdatePlatoAsync(Plato plato)
        {
            throw new NotImplementedException();
        }
    }
}
