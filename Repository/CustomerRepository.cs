using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using FluentValidationDemo.DTO;
using FluentValidationDemo.InterfaceRepositories;
using FluentValidationDemo.Models;
using FluentValidationDemo.Response;

namespace FluentValidationDemo.Repository
{
    public class CustomerRepository : RequestResponse, ICustomerRepository
    {
        private readonly IBaseRepository repository;
        private readonly IValidator<Customer> validator;
        private readonly IMapper mapper;

        private object CustormerId { get; set; }
        private ValidationResult _validationResult { get; set; }

        public CustomerRepository(IBaseRepository repository, IValidator<Customer> validator, IMapper mapper)
        {
            this.repository = repository;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<IResponse> Create(CustomerCreateDto customerDto)
        {
            var customer = mapper.Map<CustomerCreateDto, Customer>(customerDto);

            // Validate business logic
            var validationResult = validator.Validate(customer);

            if (!validationResult.IsValid)
            {
                _validationResult = validationResult;
                return OnRequest(ResponseType.Failure);
            }

            await repository.Create(customer);
            CustormerId = customer.CustomerId;
            return OnRequest(ResponseType.Success);
        }

        public async Task Delete(Guid Id)
        {
            await repository.Delete<Customer>(Id);
        }

        public async Task<Customer> Get(Guid Id)
        {
            return await repository.Get<Customer>(Id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await repository.GetDbContext().GetCustomers();
        }
        public async Task Update(CustomerUpdateDto customerDto)
        {
            var customer = mapper.Map<CustomerUpdateDto, Customer>(customerDto);
            await repository.Update(customer);
        }

        public override IResponse OnRequest(ResponseType responseType)
        {
            switch (responseType)
            {
                case ResponseType.Success:
                    return new SuccessReponse("Succes", new { customerId = CustormerId });
                case ResponseType.Failure:
                    return new FailureResponse("Failure", _validationResult);
                default: throw new ArgumentOutOfRangeException();
            }
        }

    }
}
