using System;
using System.Threading.Tasks;
using availability.application.dto;


namespace availability.application.services.clients
{
    public interface ICustomersServiceClient
    {
        Task<CustomerStateDto> GetStateAsync(Guid id);
    }
}