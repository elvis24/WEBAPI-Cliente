using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI_Cliente.Modelo.DTO;

namespace WEBAPI_Cliente.Repository
{
    public interface IClienteRepository
    {
        Task<List<ClienteDto>> GetClientes();
        Task<ClienteDto> GetClienteBy(int id);
        Task<ClienteDto> CreateUpdate(ClienteDto cliente);
        Task<bool> DeleteCliente(int id);
    }
}
