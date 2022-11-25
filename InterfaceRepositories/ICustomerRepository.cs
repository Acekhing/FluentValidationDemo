using FluentValidationDemo.DTO;
using FluentValidationDemo.Models;
using FluentValidationDemo.Response;

namespace FluentValidationDemo.InterfaceRepositories
{
    public interface ICustomerRepository
    {
        public Task<IResponse> Create(CustomerCreateDto customerDto);
        public Task Update(CustomerUpdateDto customerDto);
        public Task<Customer> Get(Guid Id);
        public Task Delete(Guid Id);
        public Task<IEnumerable<Customer>> GetAll();
    }
}
