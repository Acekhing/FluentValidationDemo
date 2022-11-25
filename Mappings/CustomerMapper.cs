using AutoMapper;
using FluentValidationDemo.DTO;
using FluentValidationDemo.Models;

namespace FluentValidationDemo.Mappings
{
    public class CustomerMapper: Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
        }
    }
}
